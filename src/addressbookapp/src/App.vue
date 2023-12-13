<script setup lang="ts">
import AddressList from "@/components/AddressList.vue";
import AddressDetails from "@/components/AddressDetails.vue";
</script>

<template>
  <div class="w-full  bg-black">
    <div class="bg-amber-950 text-gray-100 p-2 min-h-screen">
      <header>
        <h1>Address Book</h1>
      </header>
      <div class="flex gap-2">
        <address-list />
        <address-details />
      </div>
    </div>
  </div>
</template>

<style scoped></style>
