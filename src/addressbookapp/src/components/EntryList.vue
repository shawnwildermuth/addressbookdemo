<script setup lang="ts">
import { onMounted, ref } from "vue";
import { useStore } from "@/store";
import type { BookEntryModel } from "@/models/bookEntryModel";
import { formatName } from "@/formatters";
import { useRouter } from "vue-router";

const store = useStore();
const router = useRouter();
const currentId = ref(0);

function onSelected(item: BookEntryModel) {
  router.push(`/details/${item.id}`);
  currentId.value = item.id;
}

onMounted(async () => await store.loadEntries())

</script>

<template>
  <div class="border-r border-gray-200/50 py-2 px-1 text-gray-300 text-lg">
    <div class="flex flex-between">
      <input class="text-gray-900 focus:border-2" v-model="store.filter" /><button
        class="bg-gray-700 hover:gray-600" @click="store.filter = ''">x</button>
    </div>
    <div v-for="e in store.entryList" :key="e.id">
      <div @click="onSelected(e)"
        class="p-1 bg-white/10 hover:bg-white/25 cursor-pointer mb-1 border border-transparent"
        :class="{ 'border-yellow-300/50': currentId === e.id}">{{
          formatName(e) }}</div>
    </div>
  </div>
</template>