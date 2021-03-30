<template>
    <div class="home">
      <v-app>
          <v-main>
              <v-container fluid>
                <House msg="Welcome to Your Vue.js + TypeScript App"/>
              </v-container>
          </v-main>
      </v-app>
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import House from '@/components/House.vue'; // @ is an alias to /src
    
    @Component({
      components: {
        House,
      },
    })
    export default class Home extends Vue {
      
    }
</script>
