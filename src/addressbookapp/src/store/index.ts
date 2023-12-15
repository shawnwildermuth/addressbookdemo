import http from '@/http';
import { type EntryModel, 
  type EntryLookupModel } from '@/models';
import { defineStore } from "pinia"

export const useStore = defineStore("main", {
  state: () => {
    return {
      entries: new Array<EntryLookupModel>(),
      filter: ""
    };
  },
  actions: {
    async loadLookupList() {
      if (this.entries.length === 0) {
        const result = await http.get<Array<EntryLookupModel>>("/api/book/entries/lookup");
        this.entries.splice(0, this.entries.length, ...result);
      }
    },
    async getEntryById(id: Number) {
      const result = await http.get<EntryModel>(`/api/book/entries/${id}`);
      return result;
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

