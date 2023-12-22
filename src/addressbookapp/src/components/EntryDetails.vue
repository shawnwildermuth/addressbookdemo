<script setup lang="ts">
import { useStore } from '@/store';
import { onMounted, ref, watch } from 'vue';
import type { EntryModel, AddressModel } from '@/models';
import { formatName } from "@/formatters";
import ModalDialog from "@/components/ModalDialog.vue";
import { useRouter } from 'vue-router';

const store = useStore();
const currentEntry = ref<EntryModel | undefined>();
const confirmDialog = ref<typeof ModalDialog | null>(null);
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

function getGoogleMapsLink(address: AddressModel) {
  const urlAddress = `${address.line1},+${address.cityTown},+${address.stateProvince}+${address.postalCode}+${address.country}`;
  return `https://www.google.com/maps/place/${urlAddress.replace(" ", "+")}`;
}

async function updateCurrentEntry() {
  currentEntry.value = await store.getEntryById(props.id);
}

function deleteEntry() {
  confirmDialog.value?.show();
}

function editEntry() {
  router.push(`/edit/${currentEntry.value?.id}`);
}

function handleClose(confirm: boolean) {
  store.deleteEntry(currentEntry.value!);
  router.push("/");
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
        <div class=" p-2">
          <h3>Addresses</h3>
          <div>
            <div v-for="a in currentEntry?.addresses" :key="a.id"
              class=" text-lg mr-2 my-2 border-b border-gray-200">
              <div class="text-xl italic mb-2">{{ a.name }}</div>
              <div>{{ a.line1 }}</div>
              <div v-if="a.line2">{{ a.line2 }}</div>
              <div v-if="a.line3">{{ a.line3 }}</div>
              <div v-if="a.cityTown">{{ a.cityTown }},
                {{ a.stateProvince }} {{ a.postalCode }}
              </div>
              <div v-if="a.country">{{ a.country }}</div>
              <div><a :href="getGoogleMapsLink(a)" target="_blank">Map</a></div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <modal-dialog title="Are you sure?" 
    ref="confirmDialog"
    confirm-button-text="Yes"
    @close="handleClose">
    <div>Please confirm your choice.</div>
  </modal-dialog>
</template>

<style scoped>a {
  @apply text-blue-300 hover:underline;
}</style>