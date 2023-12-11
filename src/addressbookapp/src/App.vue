<script setup lang="ts">
import AddressList from "@/components/AddressList.vue";
import AddressDetails from "@/components/AddressDetails.vue";
</script>

<template>
  <div class="w-full  bg-black">
    <div class="container mx-auto bg-blue-200 text-gray-900 p-2 min-h-screen">
      <header>
        <h1>Address Book</h1>
      </header>
      <div class="grid grid-cols-2 gap-1">
        <address-list />
        <address-details />
      </div>
    </div>
  </div>
</template>

<style scoped></style>
