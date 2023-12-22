<script setup lang="ts">
import EntryList from "@/components/EntryList.vue";
import { useStore } from "@/store";

const store = useStore();
</script>

<template>
  <div class="w-full  bg-black">
    <div class="bg-gray-900 text-gray-100 p-2 h-screen">
      <header>
        <h1><router-link to="/">Address Book</router-link></h1>
      </header>
      <div class="flex gap-2  h-[calc(100vh-5rem)]">
        <entry-list />
        <div class="p-2 border rounded-lg border-gray-500/50 flex-grow">
          <div class="bg-red-500 w-full text-white" v-if="store.errorMessage">{{
            store.errorMessage }}</div>
          <div class="bg-blue-500 w-full  text-white" v-if="store.isBusy">
            Loading...
          </div>
            <router-view></router-view>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped></style>
