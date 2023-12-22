<script setup lang="ts">
import type { AddressModel, EntryModel } from '@/models';
import { useStore } from "@/store";
import { ref } from "vue";
import AddressDialog from './AddressDialog.vue';
import ConfirmationDialog from "./ConfirmationDialog.vue";

const store = useStore();
const confirmDialog = ref<typeof ConfirmationDialog>();
const addressDialog = ref<typeof AddressDialog>();
const editorAddress = ref<Address|null>(null);

const props = defineProps<{
  address: AddressModel,
  entry: EntryModel
}>();

function editAddress() {
  addressDialog.value.showModal();
}

function deleteAddress() {
  confirmDialog.value.showModal();
}

function getGoogleMapsLink() {
  const urlAddress = `${props.address.line1},+${props.address.cityTown},+${props.address.stateProvince}+${props.address.postalCode}+${props.address.country}`;
  return `https://www.google.com/maps/place/${urlAddress.replace(" ", "+")}`;
}

function confirmDelete(confirm: boolean) {
  if (confirm) {
    store.deleteAddress(props.entry, props.address);  
  }
}

function confirmSave(confirm: boolean) {

}

</script>

<template>
  <div v-if="address" class="text-lg mr-2 my-2 bg-gray-500/25 hover:bg-gray-400/25 p-1">
    <div class="flex justify-between">
      <div class="text-xl italic mb-2">{{ address.name }}</div>
      <div>
        <button @click="deleteAddress"
          class="bg-amber-900 hover:bg-amber-700 text-sm">Delete</button>
        <button @click="editAddress" class="text-sm">Edit</button>
      </div>
    </div>
    <div>{{ address.line1 }}</div>
    <div v-if="address.line2">{{ address.line2 }}</div>
    <div v-if="address.line3">{{ address.line3 }}</div>
    <div v-if="address.cityTown">{{ address.cityTown }},
      {{ address.stateProvince }} {{ address.postalCode }}
    </div>
    <div v-if="address.country">{{ address.country }}</div>
    <div><a :href="getGoogleMapsLink" target="_blank">Map</a></div>
  </div>
  <confirmation-dialog @close="confirmDelete" ref="confirmDialog">
  </confirmation-dialog>
  <address-dialog ref="addressDialog" @close="confirmSave" :address="address" :entry="entry">

  </address-dialog>
</template>

<style scoped>a {
  @apply text-blue-300 hover:underline;
}</style>