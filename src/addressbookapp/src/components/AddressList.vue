<script setup lang="ts">
import { onMounted, ref, type Ref} from "vue";
import http from "@/http";
import { type BookModel } from "@/models/bookModel";

const book: Ref<BookModel> = ref(null);

onMounted(async () => {
  const result = await http.get<BookModel>("api/book");
  book.value = result;
});
</script>

<template>
  <div class="border border-gray-500/50 min-h-full p-1">
    <h2>Address List</h2>
    <div v-for="e in book?.bookEntries" :key="e.id">
      <div>{{ e.firstName }} {{ e.lastName }}</div>
    </div>
  </div>
</template>