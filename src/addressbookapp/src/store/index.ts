import http from '@/http';
import {
  type EntryModel,
  type EntryLookupModel
} from '@/models';
import { defineStore } from "pinia"
import { formatName } from '@/formatters';

export const useStore = defineStore("main", {
  state: () => {
    return {
      entries: new Array<EntryLookupModel>(),
      filter: "",
      errorMessage: "",
      isBusy: false
    };
  },
  actions: {
    async loadLookupList() {
      if (this.entries.length === 0) {
        try {
          this.isBusy = true;
          const result = await http.get<Array<EntryLookupModel>>("/api/book/entries/lookup");
          this.entries.splice(0, this.entries.length, ...result);
          this.sortEntities();
        } catch (e: any) {
          this.errorMessage = e;
        } finally {
          this.isBusy = false;
        }
      }
    },
    async getEntryById(id: Number) {
      try {
        this.isBusy = true;
        const result = await http.get<EntryModel>(`/api/book/entries/${id}`);
        return result;
      } catch (e: any) {
        this.errorMessage = e;
      } finally {
        this.isBusy = false;
      }
    },
    async saveEntry(data: EntryModel) {
      try {
        this.isBusy = true;
        const result = await http.post<EntryModel>("/api/book/entries", data);
        this.entries.push({
          id: result.id,
          displayName: formatName(result),
        });
        this.sortEntities();
      } catch (e: any) {
        this.errorMessage = e;
      } finally {
        this.isBusy = false;
      }
    },
    sortEntities() {
      this.entries.sort((a, b) => {
        return a.displayName < b.displayName ? -1 :
          (a.displayName > b.displayName ? 1 : 0)
      });
    }
  },
  getters: {
    entryList: (state) => {
      if (state.filter) {
        return state.entries.filter((e) => e.displayName.toLowerCase().includes(state.filter));
      } else {
        return state.entries;
      }
    }
  }
});

