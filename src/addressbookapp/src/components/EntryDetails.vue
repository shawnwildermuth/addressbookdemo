<script setup lang="ts">
import { useStore } from '@/store';
import { onMounted, ref, watch } from 'vue';
import type { EntryModel, AddressModel } from '@/models';
import { formatName } from "@/formatters";
import { useRouter } from 'vue-router';
import ConfirmationDialog from "@/components/ConfirmationDialog.vue";
import AddressComponent from "@/components/AddressComponent.vue";
import AddressDialog from './AddressDialog.vue';
import {
  PencilIcon,
  TrashIcon,
  HomeIcon,
  BriefcaseIcon,
  DevicePhoneMobileIcon,
  AtSymbolIcon
} from '@heroicons/vue/24/solid';

const store = useStore();
const currentEntry = ref<EntryModel | undefined>();
const confirmDialog = ref<typeof ConfirmationDialog>();
const addressDialog = ref<typeof AddressDialog>()
const router = useRouter();

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

async function updateCurrentEntry() {
  currentEntry.value = await store.getEntryById(props.id);
}

function deleteEntry() {
  confirmDialog.value?.showModal();
}

function editEntry() {
  router.push(`/edit/${currentEntry.value?.id}`);
}

function confirmDelete(confirm: boolean) {
  if (confirm) {
    store.deleteEntry(currentEntry.value!);
    router.push("/");
  }
}

function newAddress() {
  addressDialog.value!.showModal();
}
</script>

<template>
  <div v-if="!store.isBusy">
    <div class="flex justify-between">
      <h2 class="text-xl font-semibold" v-if="currentEntry">{{
        formatName(currentEntry) }}</h2>
      <div>
        <button class="btn btn-sm btn-warning btn-outline mr-2" @click="deleteEntry">
          <trash-icon class="w-5"></trash-icon> Delete
        </button>
        <button class="btn btn-sm btn-primary" @click="editEntry">
          <pencil-icon class="w-5"></pencil-icon> Edit
        </button>
      </div>
    </div>
    <div class="text-lg">
      <div v-if="currentEntry?.companyName"><strong>{{ currentEntry?.companyName
      }}
      </strong></div>
      <div v-if="currentEntry?.homePhone"><home-icon
          class="w-4 inline"></home-icon> <a
          :href="`tel:${currentEntry.homePhone}`">{{ currentEntry?.homePhone
          }}</a>
      </div>
      <div v-if="currentEntry?.workPhone"><briefcase-icon
          class="w-4 inline"></briefcase-icon> <a
          :href="`tel:${currentEntry.workPhone}`">{{ currentEntry?.workPhone
          }}</a>
      </div>
      <div v-if="currentEntry?.cellPhone"><device-phone-mobile-icon
          class="w-4 inline"></device-phone-mobile-icon> <a
          :href="`tel:${currentEntry.cellPhone}`">{{ currentEntry?.cellPhone
          }}</a>
      </div>
      <div v-if="currentEntry?.email"><at-symbol-icon
          class="w-4 inline"></at-symbol-icon> <a
          :href="`mailto:${currentEntry.email}`">{{
            currentEntry?.email }}</a></div>
      <div v-if="currentEntry?.gender">{{ currentEntry?.gender }}</div>
      <div v-if="currentEntry?.addresses && currentEntry?.addresses.length > 0"
        class="ml-4 mr-2 my-2">
        <div class="p-2">
          <div class="flex justify-between">
            <h3>Addresses</h3>
            <button class="btn btn-sm btn-primary" @click="newAddress">New
              Address</button>
          </div>
          <div>
            <address-component v-for="address in currentEntry?.addresses"
              :key="address.id" :address="address" :entry="currentEntry">
            </address-component>
          </div>
        </div>
      </div>
    </div>
  </div>
  <confirmation-dialog @close="confirmDelete" ref="confirmDialog">
  </confirmation-dialog>

  <address-dialog v-if="currentEntry" ref="addressDialog" :entry="currentEntry!" :address="null">
  </address-dialog>
</template>

<style scoped>
a {
  @apply hover:text-yellow-500;
}
</style>

