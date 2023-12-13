<script setup lang="ts">
import EntryList from "@/components/EntryList.vue";
</script>

<template>
  <div class="w-full  bg-black">
    <div class="bg-gray-900 text-gray-100 p-2 min-h-screen">
      <header>
        <h1><router-link to="/">Address Book</router-link></h1>
      </header>
      <div class="flex gap-2">
        <entry-list />
        <div class="p-2 border rounded-lg border-gray-500/50 flex-grow">
          <router-view></router-view>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped></style>
