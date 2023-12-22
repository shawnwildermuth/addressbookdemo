<script setup lang="ts">
import { onMounted, ref, watch } from "vue";
import { useStore } from "@/store";
import type { EntryLookupModel } from "@/models";
import { useRouter } from "vue-router";

const store = useStore();
const router = useRouter();
const currentId = ref(0);

function onSelected(item: EntryLookupModel) {
  router.push(`/details/${item.id}`);
  currentId.value = item.id;
}

onMounted(async () => {
  await store.loadLookupList();
})

watch(router.currentRoute, () => {
  if (router.currentRoute.value.name === "home") {
    currentId.value = 0;
  }
})

</script>

<template>
  <div class="w-48border-r border-gray-200/50 py-2 px-1 text-gray-300 text-lg">
    <div class="flex justify-start"><a href="/edit/-1"
        class="px-1 bg-blue-700 text-white rounded hover:bg-blue-500">New</a>
    </div>
    <div class="flex flex-between">
      <input class="text-gray-900 focus:border-2" v-model="store.filter" /><button
        class="bg-gray-700 hover:gray-600" @click="store.filter = ''">x</button>
    </div>
    <div class="h-[calc(100vh-10rem)] overflow-y-scroll bg-yellow">
      <div v-for="e in store.entryList" :key="e.id">
        <div @click="onSelected(e)"
          class="p-1 bg-white/10 hover:bg-white/25 cursor-pointer mb-1 border border-transparent"
          :class="{ 'border-yellow-300/50': currentId === e.id }">{{ e.displayName
          }}</div>
      </div>
    </div>
  </div>
</template>