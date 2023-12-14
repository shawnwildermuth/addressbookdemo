import EntryDetailsVue from "@/components/EntryDetails.vue";
import NoEntryVue from "@/components/NoEntry.vue";
import { createRouter, createWebHistory, type RouteRecordRaw } from "vue-router";
import { useStore } from "@/store";

const routes: Array<RouteRecordRaw> = [
  {
    name: "home",
    path: "/",
    component: NoEntryVue
  },
  {
    name: "entry",
    path: "/details/:id",
    component: EntryDetailsVue,
    props: route => ({ id: Number(route.params.id) }),
  },
  {
    name: "editor",
    path: "/edit/:id",
    component: EntryDetailsVue,
    props: route => ({ id: Number(route.params.id) }),
  },
  {
    name: "fallback",
    path: '/:pathMatch(.*)',
    redirect: "/"
  }
];


export default function () {
  const store = useStore();

  const router = createRouter({
    routes,
    history: createWebHistory()
  });
  
  router.beforeEach(async (to) => {
    await store.loadEntries();
    if (!store.entries) {
      if (to.name !== "home" ) {
        return { name: "home" };
      }
    }
    return true;
  })
  
  return router;
}