<script setup lang="ts">
import { useStore } from '@/store';
import { onMounted, ref, watch } from 'vue';
import { type BookEntryModel } from '@/models/bookEntryModel';
import { formatName } from "@/formatters";

const store = useStore();
const currentEntry = ref<BookEntryModel | undefined>();

const props = defineProps<{
  id: Number
}>();

// onMounted(() => {
//   currentEntry.value = store.getEntryById(props.id);
// })

watch(() => props.id,
  () => {
    currentEntry.value = store.getEntryById(Number(props.id));
  });
</script>

<template>
  <h2 v-if="currentEntry">{{ formatName(currentEntry) }}</h2>
</template>