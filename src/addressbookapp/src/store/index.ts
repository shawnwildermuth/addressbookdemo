import http from '@/http';
import { type BookModel } from '@/models/bookModel';
import { reactive } from "vue";

const store = reactive({
  book: null as BookModel | null,
  async loadBook() {
    const result = await http.get<BookModel>("api/book");
    this.book = result;
  }
});

export function useStore() {
  return store;
}