<script setup lang="ts">
import { useStore } from '@/store';
import { bus } from "@/bus";
import { ref } from 'vue';
import { type BookEntryModel } from '@/models/bookEntryModel';

const store = useStore();
const currentEntry = ref<BookEntryModel | undefined>()
bus.on("showEntry", (id: Number) => {
  currentEntry.value = store.book?.bookEntries.find(e => e.id === id);
});

</script>

<template>
  <div class="min-h-full flex-grow ">
    <h2>Address Details</h2>
    <div>{{ currentEntry?.lastName }}</div>
  </div>
</template>