<script setup lang="ts">
import type { BookEntryModel } from '@/models/bookEntryModel';
import { useStore } from '@/store';
import { onMounted, ref } from 'vue';
import { cloneDeep } from "lodash";
import { useRouter } from 'vue-router';
import { entrySchema } from "@/schemas/BookEntry";
import { type ZodErrorMap, type inferFormattedError } from "zod";

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
    entry.value = {} as BookEntryModel;
  } else {
    const original = store.getEntryById(props.id);
    const copy = cloneDeep(original);
    entry.value = copy;
  }
});

function save() {
  const result = entrySchema.safeParse(entry.value);
  if (result.success) {
    console.log("ready to save");
  } else {
    errors.value = result.error.format();
  }
}

</script>
<template>
  <div class="flex flex-col" v-if="entry">
    <label>Name</label>
    <div class="flex justify-stretch gap-1 flex-col md:flex-row">
      <input placeholder="first name" v-model="entry.firstName" />
      <input class="w-36" placeholder="middle name" v-model="entry.middleName" />
      <input placeholder="last name" v-model="entry.lastName" />
    </div>
    <!-- Make Component Next -->
    <div class="text-red-500" v-if="errors?.firstName">
      <div v-for="e in errors.firstName._errors" :key="e">
        {{ e }}
      </div>
    </div>
    <label>Email</label>
    <input placeholder="e.g. you@us.net" v-model="entry.email" />
    <label>Company Name</label>
    <input placeholder="e.g. My Company, LLC" v-model="entry.companyName" />
    <label>Home Phone</label>
    <input placeholder="e.g. +1 404 227 3030" v-model="entry.homePhone" />
    <label>Work Phone</label>
    <input placeholder="e.g. +1 404 227 3030" v-model="entry.workPhone" />
    <label>Cell Phone</label>
    <input placeholder="e.g. +1 404 227 3030" v-model="entry.cellPhone" />
    <label>Gender</label>
    <select class="" v-model="entry.gender">
      <option>Select One...</option>
      <option>Male</option>
      <option>Female</option>
      <option>Non-binary</option>
      <option>Intersex</option>
      <option>Other</option>
    </select>
    <div class="flex justify-end">
      <button @click="save">Save</button>
      <button class="bg-gray-500 hover:bg-gray-700"
        @click="router.push('/')">Cancel</button>
    </div>
  </div>
  <pre>{{ entry }}</pre>
</template>