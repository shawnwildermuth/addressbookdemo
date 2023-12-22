<script setup lang="ts">
import type { AddressModel } from '@/models';
import ModalDialog from './ModalDialog.vue';
import { useStore } from '@/store';
import { useRouter } from 'vue-router';
import type { inferFormattedError } from 'zod';
import { onMounted, ref } from 'vue';
import { addressSchema } from "@/schemas/address";
import { cloneDeep } from "lodash";

const props = defineProps<{
  entityId: Number
  id: Number
}>();

const store = useStore();
const router = useRouter();

const address = ref<AddressModel>();

type ErrorsType = inferFormattedError<typeof addressSchema>;

const errors = ref<ErrorsType>();

onMounted(() => {
  if (props.id === -1) {// new
    address.value = {
      id: 0,
      name: "Home",
      line1: "123 Main Street",
      line2: "",
      line3: "",
      cityTown: "Atlanta",
      stateProvince: "GA",
      postalCode: "30303",
      country: ""
    };
  } else {
    const original = store.getAddressById(props.entityId, props.id);
    const copy = cloneDeep(original);
    address.value = copy;
  }
});

async function onSave(success: boolean) {
  const result = addressSchema.safeParse(address.value);
  if (result.success) {
    let id = props.id;
    // If New
    if (props.id === -1) {
      // const newId = await store.saveAddress(address.value!);
      // if (newId) id = newId;
    } else {
      // update
      // const newId = await store.updateAddress(address.value!);
      // if (newId) id = newId;
    }
    router.push({ name: "entry", params: { id: id.toString() }})
  } else {
    errors.value = result.error.format();
  }
}
</script>

<template>
  <modal-dialog title="Address" confirm-button-text="Save" @close="onSave">
    <div v-if="address">
      <label>Address Name</label>
      <input placeholder="e.g. Home" v-model="address.name" />
      <ValidationError :errors="errors" fieldName="name" />
      <label>Street Address</label>
      <input placeholder="e.g. you@us.net" v-model="address.line1" />
      <ValidationError :errors="errors" fieldName="email" />
      <input placeholder="e.g. you@us.net" v-model="address.line2" />
      <ValidationError :errors="errors" fieldName="email" />
      <input placeholder="e.g. you@us.net" v-model="address.line3" />
      <ValidationError :errors="errors" fieldName="email" />
      <label>City</label>
      <input placeholder="e.g. Home" v-model="address.cityTown" />
      <ValidationError :errors="errors" fieldName="cityTown" />
      <label>State/Province</label>
      <input placeholder="e.g. Home" v-model="address.stateProvince" />
      <ValidationError :errors="errors" fieldName="stateProvince" />
      <label>Postal Code</label>
      <input placeholder="e.g. Home" v-model="address.postalCode" />
      <ValidationError :errors="errors" fieldName="postalCode" />
      <label>Country</label>
      <input placeholder="e.g. Home" v-model="address.country" />
      <ValidationError :errors="errors" fieldName="postalCode" />
    </div>
  </modal-dialog>
</template>

<style scoped>
/* Your component's CSS styles go here */
</style>
