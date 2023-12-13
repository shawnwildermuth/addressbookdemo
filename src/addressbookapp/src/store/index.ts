import http from '@/http';
import type { BookEntryModel } from '@/models/bookEntryModel';
import { type BookModel } from '@/models/bookModel';
import { defineStore } from "pinia"

export const useStore = defineStore("main", {
  state: () => {
    return {
      entries: new Array<BookEntryModel>(),
      filter: ""
    };
  },
  actions: {
    async loadEntries() {
      if (this.entries.length === 0) {
        const result = await http.get<BookModel>("/api/book");
        this.entries.splice(0, this.entries.length, ...result.bookEntries);
      }
    },
    getEntryById(id: Number): BookEntryModel | undefined {
      return this.entries.find(e => e.id === id);
    }
  },
  getters: {
    entryList: (state) => {
      if (state.filter) {
        return state.entries.filter((e) => {
            return e.firstName?.toLowerCase().includes(state.filter) ||
              e.lastName?.toLowerCase().includes(state.filter) ||
              e.companyName?.toLowerCase().includes(state.filter);
        });
      } else {
        return state.entries;
      }
    }
  }
});

