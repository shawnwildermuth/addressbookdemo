<script setup lang="ts">
import { useStore } from '@/store';
import { computed, onMounted, ref, watch } from 'vue';
import { type BookEntryModel } from '@/models/bookEntryModel';
import { formatName } from "@/formatters";
import type { AddressModel } from '@/models/addressModel';

const store = useStore();
const currentEntry = ref<BookEntryModel | undefined>();
const currentAddress = ref<AddressModel | undefined>();

const props = defineProps<{
  id: Number
}>();

onMounted(() => {
  updateCurrentEntry();
})

watch(() => props.id,
  () => {
    updateCurrentEntry();
  });

const googleMapsLink = computed(() => {
  if (!currentAddress.value) return undefined;
  const urlAddress = `${currentAddress.value?.line1},+${currentAddress.value?.cityTown},+${currentAddress.value?.stateProvince}+${currentAddress.value?.postalCode}+${currentAddress.value?.country}`;
  return `https://www.google.com/maps/place/${urlAddress.replace(" ", "+")}`;
});

async function updateCurrentEntry() {
  currentEntry.value = await store.getEntryById(props.id);
  currentAddress.value = currentEntry.value?.addresses[0] ?? undefined;
}
</script>

<template>
  <h2 v-if="currentEntry">{{ formatName(currentEntry) }}</h2>
  <div class="text-xl">
    <div v-if="currentEntry?.companyName">Company: {{ currentEntry?.companyName }}
    </div>
    <div v-if="currentEntry?.homePhone">home: <a
        :href="`tel:${currentEntry.homePhone}`">{{ currentEntry?.homePhone }}</a>
    </div>
    <div v-if="currentEntry?.workPhone">work: <a
        :href="`tel:${currentEntry.workPhone}`">{{ currentEntry?.workPhone }}</a>
    </div>
    <div v-if="currentEntry?.cellPhone">cell: <a
        :href="`tel:${currentEntry.cellPhone}`">{{ currentEntry?.cellPhone }}</a>
    </div>
    <div v-if="currentEntry?.email"><a :href="`mailto:${currentEntry.email}`">{{
      currentEntry?.email }}</a></div>
    <div v-if="currentEntry?.gender">{{ currentEntry?.gender }}</div>
    <div v-if="currentEntry?.addresses" class="ml-4 mr-2 my-2">
      <h3>Addresses</h3>
      <div class="shadow-xl border rounded border-gray-200/25  p-2">
        <div class="flex mb-2 border-b border-gray-200">
          <div v-for="a in currentEntry?.addresses" :key="a.id" class="mr-2">
            <div class="cursor-pointer"
            :class="{ 'text-blue-400': currentAddress?.id === a.id}"
              @click="currentAddress = a">
              {{ a.name ?? "Address" }}</div>
          </div>
        </div>
        <div v-if="currentAddress">
          <div>{{ currentAddress.line1 }}</div>
          <div v-if="currentAddress.line2">{{ currentAddress.line2 }}</div>
          <div v-if="currentAddress.line3">{{ currentAddress.line3 }}</div>
          <div v-if="currentAddress.cityTown">{{ currentAddress.cityTown }}, {{ currentAddress.stateProvince }}  {{ currentAddress.postalCode }}</div>
          <div v-if="currentAddress.country">{{ currentAddress.country}}</div>
          <div><a :href="googleMapsLink" target="_blank">Map</a></div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
a {
  @apply text-blue-300 hover:underline;
}
</style>