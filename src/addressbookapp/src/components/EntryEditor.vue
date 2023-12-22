<script setup lang="ts">
import type { EntryModel } from '@/models';
import { useStore } from '@/store';
import { onMounted, reactive, ref, watch } from 'vue';
import { cloneDeep } from "lodash";
import { useRouter } from 'vue-router';
import { entrySchema } from "@/schemas/bookEntry";
import { type inferFormattedError } from "zod";
import ValidationError from './ValidationError.vue';

const store = useStore();

const router = useRouter();

const props = defineProps<{
  id: Number
}>();

const entry = ref<EntryModel>();
const isDirty = ref(false);

type ErrorsType = inferFormattedError<typeof entrySchema>;

const errors = ref<ErrorsType>();

onMounted(async () => {
  if (props.id === -1) {// new
    entry.value = {
      id: 0,
      firstName: "Shawn",
      middleName: "",
      lastName: "Wildermuth",
      email: "shawn@aol.com",
      gender: "Pick One...",
      dateOfBirth: "",
      cellPhone: "",
      homePhone: "",
      workPhone: "",
      companyName: "",
      addresses: [],
    };
  } else {
    const original = await store.getEntryById(props.id);
    if (!original) router.push("/"); 
    const copy = cloneDeep(original) as EntryModel;
    entry.value = copy;
  }
});

function onChange() {
  isDirty.value = true;
}

async function save() {
  const result = entrySchema.safeParse(entry.value);
  if (result.success) {
    let id = props.id;
    let success = false;
    // If New
    if (props.id === -1) {
      const newId = await store.saveEntry(entry.value!);
      if (newId) id = newId;
      success = true;
    } else {
      // update
      if (await store.updateEntry(entry.value!)) {
        success = true;
      } else {
        store.errorMessage = "Failed to update entry.";
      } 
    }
    if (success) {
      router.push({ name: "entry", params: { id: id.toString() } });
    }
  } else {
    errors.value = result.error.format();
  }
}

</script>
<template>
  <div class="flex flex-col mx-0 lg:mx-36" v-if="entry">
    <label>Name</label>
    <div class="flex justify-stretch gap-1 flex-col md:flex-row">
      <div class="flex flex-col">
        <input placeholder="first name" v-model="entry.firstName" @input="onChange" />
        <ValidationError :errors="errors" fieldName="firstName" />
      </div>
      <div class="flex flex-col">
        <input class="w-36" placeholder="middle name"
          v-model="entry.middleName" @input="onChange"  />
        <ValidationError :errors="errors" fieldName="middleName" />
      </div>
      <div class="flex flex-col">
        <input placeholder="last name" v-model="entry.lastName" @input="onChange"  />
        <ValidationError :errors="errors" fieldName="lastName" />
      </div>
    </div>
    <label>Email</label>
    <input placeholder="e.g. you@us.net" v-model="entry.email" @input="onChange"  />
    <ValidationError :errors="errors" fieldName="email" />
    <label>Company Name</label>
    <input placeholder="e.g. My Company, LLC" v-model="entry.companyName" @input="onChange"  />
    <ValidationError :errors="errors" fieldName="companyName" />
    <label>Home Phone</label>
    <input placeholder="e.g. +1 404 227 3030" v-model="entry.homePhone" @input="onChange"  />
    <ValidationError :errors="errors" fieldName="homePhone" />
    <label>Work Phone</label>
    <input placeholder="e.g. +1 404 227 3030" v-model="entry.workPhone" @input="onChange"  />
    <ValidationError :errors="errors" fieldName="workPhone" />
    <label>Cell Phone</label>
    <input placeholder="e.g. +1 404 227 3030" v-model="entry.cellPhone" @input="onChange"  />
    <ValidationError :errors="errors" fieldName="cellPhone" />
    <label>Gender</label>
    <select class="" v-model="entry.gender" @input="onChange"  >
      <option selected value="">Select One...</option>
      <option>Male</option>
      <option>Female</option>
      <option>Non-binary</option>
      <option>Intersex</option>
      <option>Other</option>
    </select>
    <ValidationError :errors="errors" fieldName="gender" />
    <label>Birthdate</label>
    <input placeholder="2000-01-01" v-model="entry.dateOfBirth" @input="onChange"  />
    <ValidationError :errors="errors" fieldName="dateOfBirth" />
    <div class="flex justify-end">
      <button @click="save" :disabled="!isDirty">Save</button>
      <button class="bg-gray-500 hover:bg-gray-700"
        @click="router.push('/')">Cancel</button>
    </div>
  </div>
  <pre>{{ entry }}</pre>
</template>@/schemas/bookEntry