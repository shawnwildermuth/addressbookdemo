<script setup lang="ts">

const props = defineProps<{
  id: Number
}>();

</script>
<template>
    <div v-if="currentEntry?.companyName">Company: {{ currentEntry?.companyName }}
    </div>
    <div v-if="currentEntry?.homePhone">home: <a
        :href="`tel:${currentEntry.homePhone}`">{{ currentEntry?.homePhone }}</a>
    </div>
    <div v-if="currentEntry?.workPhone">work: <a
        :href="`tel:${currentEntry.workPhone}`">{{ currentEntry?.workPhone }}</a>
    </div>
    <div v-if="currentEntry?.cellPhone">cell: <a
        :href="`tel:${currentEntry.cellPhone}`">{{ currentEntry?.cellPhone }}</a>
    </div>
    <div v-if="currentEntry?.email"><a :href="`mailto:${currentEntry.email}`">{{
      currentEntry?.email }}</a></div>
    <div v-if="currentEntry?.gender">{{ currentEntry?.gender }}</div>
</template>