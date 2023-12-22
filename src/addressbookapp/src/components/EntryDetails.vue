<script setup lang="ts">
import { useStore } from '@/store';
import { onMounted, ref, watch } from 'vue';
import type { EntryModel, AddressModel } from '@/models';
import { formatName } from "@/formatters";
import { useRouter } from 'vue-router';
import ConfirmationDialog from "@/components/ConfirmationDialog.vue";
import AddressComponent from "@/components/AddressComponent.vue";

const store = useStore();
const currentEntry = ref<EntryModel | undefined>();
const confirmDialog = ref<typeof ConfirmationDialog>();
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

}
</script>

<template>
  <div v-if="!store.isBusy">
    <div class="flex justify-between">
      <h2 v-if="currentEntry">{{ formatName(currentEntry) }}</h2>
      <div>
        <button class="bg-gray-700 hover:bg-gray-800" @click="deleteEntry">Delete</button>
        <button class="bg-green-700 hover:bg-green-900" @click="editEntry">Edit</button>
      </div>
    </div>
    <div class="text-xl">
      <div v-if="currentEntry?.companyName">Company: {{ currentEntry?.companyName
      }}
      </div>
      <div v-if="currentEntry?.homePhone">home: <a
          :href="`tel:${currentEntry.homePhone}`">{{ currentEntry?.homePhone
          }}</a>
      </div>
      <div v-if="currentEntry?.workPhone">work: <a
          :href="`tel:${currentEntry.workPhone}`">{{ currentEntry?.workPhone
          }}</a>
      </div>
      <div v-if="currentEntry?.cellPhone">cell: <a
          :href="`tel:${currentEntry.cellPhone}`">{{ currentEntry?.cellPhone
          }}</a>
      </div>
      <div v-if="currentEntry?.email"><a :href="`mailto:${currentEntry.email}`">{{
        currentEntry?.email }}</a></div>
      <div v-if="currentEntry?.gender">{{ currentEntry?.gender }}</div>
      <div v-if="currentEntry?.addresses && currentEntry?.addresses.length > 0"
           class="ml-4 mr-2 my-2">
        <div class="p-2">
          <div>
            <h3>Addresses</h3>
            <button class="ml-0 p-2 text-sm" @click="newAddress">New Address</button>
          </div>
          <div>
            <address-component v-for="address in currentEntry?.addresses" 
                               :key="address.id" 
                               :address="address"
                               :entry="currentEntry">
            </address-component>
          </div>
        </div>
      </div>

    </div>
  </div>
  <confirmation-dialog @close="confirmDelete" ref="confirmDialog">
  </confirmation-dialog>
</template>

