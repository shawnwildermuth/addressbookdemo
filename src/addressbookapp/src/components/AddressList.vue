<script setup lang="ts">
import { onMounted, reactive, ref, watch } from "vue";
import { useStore } from "@/store";
import { bus } from '@/bus';
import type { BookEntryModel } from "@/models/bookEntryModel";

const store = useStore();
const search = ref("");
const items = reactive(new Array<BookEntryModel>());
const currentId = ref(0);

onMounted(async () => {
  await store.loadBook();
  if (store.book) {
    items.splice(0, items.length, ...store.book.bookEntries);
  }
});

function onSelected(item: BookEntryModel) {
  bus.emit("showEntry", item.id);
  currentId.value = item.id;
}

function formatName(entry?: BookEntryModel) {
  if (entry?.firstName && entry.lastName) {
    return `${entry.lastName}, ${entry.firstName}`;
  } else if (entry?.firstName) {
    return entry.firstName;
  } else if (entry?.lastName) {
    return entry.lastName;
  } else if (entry?.companyName) {
    return entry.companyName;
  } else {
    return "Undefined Name";
  }
}

function filter(key: string) {
  return store.book?.bookEntries.filter(e => {
    console.log(e);
    return e.firstName?.toLowerCase().includes(key) ||
      e.lastName?.toLowerCase().includes(key) ||
      e.companyName?.toLowerCase().includes(key);
  });
}

watch(search,
  () => {
    if (store.book) {
      if (search.value) {
        // Perform filtering
        items.splice(0, items.length, ...filter(search.value));
      } else {
        // Clear filtering
        items.splice(0, items.length, ...store.book.bookEntries);
      }
    }
  });
</script>

<template>
  <div class="border-r border-gray-200/50 py-2 px-1 text-gray-300 text-lg">
    <div class="flex flex-between">
      <input class="text-gray-900 focus:border-2" v-model="search" /><button
        class="bg-gray-700 hover:gray-600" @click="search = ''">x</button>
    </div>
    <div v-for="e in items" :key="e.id">
      <div @click="onSelected(e)"
        class="p-1 bg-white/10 hover:bg-white/25 cursor-pointer mb-1 border border-transparent"
        :class="{ 'border-yellow-300/50': currentId === e.id}">{{
          formatName(e) }}</div>
    </div>
  </div>
</template>