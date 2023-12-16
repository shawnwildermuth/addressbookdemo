<script setup lang="ts">
import type { BookEntryModel } from '@/models';
import { useStore } from '@/store';
import { onMounted, ref } from 'vue';
import { cloneDeep } from "lodash";
import { useRouter } from 'vue-router';
import { entrySchema } from "@/schemas/BookEntry";
import { type inferFormattedError } from "zod";
import ValidationError from './ValidationError.vue';

const store = useStore();

const router = useRouter();

const props = defineProps<{
  id: Number
}>();

const entry = ref<BookEntryModel>();

type ErrorsType = inferFormattedError<typeof entrySchema>;

const errors = ref<ErrorsType | null>(null)

onMounted(() => {
  if (props.id === -1) {// new
    entry.value = {
      firstName: "Shawn",
      lastName: "Wildermuth",
      email: "shawn@aol.com",
      gender: "Pick One...",
      cellPhone: "",
      homePhone: "",
      workPhone: "",
    };
  } else {
    const original = store.getEntryById(props.id);
    const copy = cloneDeep(original);
    entry.value = copy;
  }
});

function save() {
  const result = entrySchema.safeParse(entry.value);
  if (result.success) {
    // If New
    if (props.id === -1) {
      store.saveEntry(entry.value);
    } else {
      // update
    }
  } else {
    errors.value = result.error.format();
  }
}

</script>
<template>
  <div class="flex flex-col mx-36" v-if="entry">
    <label>Name</label>
    <div class="flex justify-stretch gap-1 flex-col md:flex-row">
      <div class="flex flex-col">
        <input placeholder="first name" v-model="entry.firstName" />
        <ValidationError :errors="errors" fieldName="firstName" />
      </div>
      <div class="flex flex-col">
        <input class="w-36" placeholder="middle name"
          v-model="entry.middleName" />
          <ValidationError :errors="errors" fieldName="middleName" />
      </div>
      <div class="flex flex-col">
        <input placeholder="last name" v-model="entry.lastName" />
        <ValidationError :errors="errors" fieldName="lastName" />
      </div>
    </div>
    <label>Email</label>
    <input placeholder="e.g. you@us.net" v-model="entry.email" />
    <ValidationError :errors="errors" fieldName="email" />
    <label>Company Name</label>
    <input placeholder="e.g. My Company, LLC" v-model="entry.companyName" />
    <ValidationError :errors="errors" fieldName="companyName" />
    <label>Home Phone</label>
    <input placeholder="e.g. +1 404 227 3030" v-model="entry.homePhone" />
    <ValidationError :errors="errors" fieldName="homePhone" />
    <label>Work Phone</label>
    <input placeholder="e.g. +1 404 227 3030" v-model="entry.workPhone" />
    <ValidationError :errors="errors" fieldName="workPhone" />
    <label>Cell Phone</label>
    <input placeholder="e.g. +1 404 227 3030" v-model="entry.cellPhone" />
    <ValidationError :errors="errors" fieldName="cellPhone" />
    <label>Gender</label>
    <select class="" v-model="entry.gender">
      <option selected value="">Select One...</option>
      <option>Male</option>
      <option>Female</option>
      <option>Non-binary</option>
      <option>Intersex</option>
      <option>Other</option>
    </select>
    <ValidationError :errors="errors" fieldName="gender" />
    <label>Birthdate</label>
    <input placeholder="2000-01-01" v-model="entry.dateOfBirth" />
    <ValidationError :errors="errors" fieldName="dateOfBirth" />
    <div class="flex justify-end">
      <button @click="save">Save</button>
      <button class="bg-gray-500 hover:bg-gray-700"
        @click="router.push('/')">Cancel</button>
    </div>
  </div>
  <pre>{{ entry }}</pre>
</template>