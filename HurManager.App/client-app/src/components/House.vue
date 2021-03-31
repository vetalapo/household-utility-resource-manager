<template>
  <v-data-table
    :headers="headers"
    :items="houses"
    sort-by="id"
    class="elevation-1"
  >
    <template v-slot:top>
      <v-toolbar
        flat
      >
        <v-toolbar-title>Houses List</v-toolbar-title>
        <v-divider
          class="mx-4"
          inset
          vertical
        ></v-divider>
        <v-spacer></v-spacer>
        <v-dialog
          v-model="dialog"
          max-width="500px"
        >
          <template v-slot:activator="{ on, attrs }">
            <v-btn
              color="primary"
              dark
              class="mb-2"
              v-bind="attrs"
              v-on="on"
            >
              New House
            </v-btn>
          </template>
          <v-card>
            <v-card-title>
              <span class="headline">{{ formTitle }}</span>
            </v-card-title>

            <v-card-text>
              <v-container>
                <v-row>
                  <v-col
                    cols="12"
                    sm="6"
                    md="4"
                  >
                    <v-text-field
                      v-model="editedItem.name"
                      label="House address"
                    ></v-text-field>
                  </v-col>
                </v-row>
              </v-container>
            </v-card-text>

            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn
                color="blue darken-1"
                text
                @click="close"
              >
                Cancel
              </v-btn>
              <v-btn
                color="blue darken-1"
                text
                @click="save"
              >
                Save
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
        <v-dialog v-model="dialogDelete" max-width="500px">
          <v-card>
            <v-card-title class="headline">Are you sure you want to delete this item?</v-card-title>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="blue darken-1" text @click="closeDelete">Cancel</v-btn>
              <v-btn color="blue darken-1" text @click="deleteItemConfirm">OK</v-btn>
              <v-spacer></v-spacer>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </v-toolbar>
    </template>
    <template v-slot:[`item.actions`]="{ item }">
      <v-icon
        small
        class="mr-2"
        @click="editItem(item)"
      >
        mdi-pencil
      </v-icon>
      <v-icon
        small
        @click="deleteItem(item)"
      >
        mdi-delete
      </v-icon>
    </template>
    <template v-slot:no-data>
      <v-btn
        color="primary"
        @click="initialize"
      >
        Reset
      </v-btn>
    </template>
  </v-data-table>
</template>

<script lang="ts">
import { Component, Prop, Vue, Inject, Watch } from 'vue-property-decorator';
import axios from "axios";

@Component
export default class House extends Vue {
  @Prop() private msg!: string;

  houses = [];
  editedItem = {};
  defaultItem = {};

  headers = [
    {
      text: "Address",
      sortable: true,
      value: "address"
    },
    {
      text: "Water Meter",
      sortable: false,
      value: "waterMeterFactoryNumber"
    },
    {
      text: "Reading",
      sortable: false,
      value: "waterMeterReading"
    },
    {
      text: "Actions",
      value: "actions",
      sortable: false
    }
  ];

  dialog = false;
  dialogDelete = false;
  editedIndex = -1;

  async created() {
       await this.initialize();
  }

  async initialize() {
    this.houses = (await axios.get("http://localhost:51830/api/house/list")).data.result;
  }

  get formTitle() {
      return this.editedIndex === -1 ? 'New House' : 'Edit House'
  }

  editItem(item: any) {
      this.editedIndex = this.houses.indexOf(item)
      this.editedItem = Object.assign({}, item)
      this.dialog = true
  }

  deleteItem(item: any) {
      this.editedIndex = this.houses.indexOf(item)
      this.editedItem = Object.assign({}, item)
      this.dialogDelete = true
  }

  deleteItemConfirm() {
      this.houses.splice(this.editedIndex, 1)
      this.closeDelete()
  }

  close() {
      this.dialog = false
      this.$nextTick(() => {
        this.editedItem = Object.assign({}, this.defaultItem)
        this.editedIndex = -1
      })
  }

  closeDelete() {
      this.dialogDelete = false
      this.$nextTick(() => {
          this.editedItem = Object.assign({}, this.defaultItem)
          this.editedIndex = -1
      })
  }

  save() {
      if (this.editedIndex > -1) {
          Object.assign(this.houses[this.editedIndex], this.editedItem)
      } else {
          this.houses.push(this.editedItem)
      }
      
      this.close()
  }
  
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
