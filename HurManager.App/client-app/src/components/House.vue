<template>
  <v-container>
    <v-data-table
      :headers="headers"
      :items="houses"
      sort-by="id"
      class="elevation-1"
    >
      <template v-slot:top>
        <v-toolbar flat>
          <v-toolbar-title>Houses List</v-toolbar-title>
          <v-divider class="mx-4" inset vertical></v-divider>
          <v-spacer></v-spacer>
          <v-dialog v-model="dialogAddReading" max-width="500px">
            <template v-slot:activator="{ on, attrs }">
              <v-btn color="primary" dark class="mb-2" v-bind="attrs" v-on="on">Add Reading</v-btn>
            </template>
            <v-card>
              <v-card-title>
                <span class="headline">Add Reading</span>
              </v-card-title>
              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col cols="12" sm="10" md="12">
                      <v-text-field v-model="readingItem.identifier" label="Meter Factory Number or House ID" :rules="[rules.required]"></v-text-field>
                    </v-col>
                    <v-col cols="12" sm="10" md="12">
                      <v-text-field v-model="readingItem.reading" label="House reading" type="number" min="0" :rules="[rules.required]"></v-text-field>
                    </v-col>
                  </v-row>
                </v-container>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="addReadingClose">Cancel</v-btn>
                <v-btn color="blue darken-1" text @click="addReadingSave">Save</v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
          <v-dialog v-model="dialogAddWaterMeter" max-width="500px">
            <v-card>
              <v-card-title>
                <span class="headline">Add Water Meter</span>
              </v-card-title>
              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col cols="12" sm="10" md="12">
                      <v-text-field v-model="waterMeterItem.factoryNumber" label="Meter Factory Number" :rules="[rules.required, rules.min]"></v-text-field>
                    </v-col>
                    <v-col cols="12" sm="10" md="12">
                      <v-text-field v-model="waterMeterItem.reading" label="House reading" type="number" min="0" :rules="[rules.required]"></v-text-field>
                    </v-col>
                  </v-row>
                </v-container>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="dialogAddWaterMeter = !dialogAddWaterMeter">Cancel</v-btn>
                <v-btn color="blue darken-1" text @click="registerNewWaterMeterSave">Save</v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
          <v-divider class="mx-4" inset vertical></v-divider>
          <v-dialog v-model="dialog" max-width="500px">
            <template v-slot:activator="{ on, attrs }">
              <v-btn color="primary" dark class="mb-2" v-bind="attrs" v-on="on">New House</v-btn>
            </template>
            <v-card>
              <v-card-title>
                <span class="headline">{{ formTitle }}</span>
              </v-card-title>
              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col cols="12" sm="10" md="12">
                      <v-text-field v-model="editedItem.address" label="House address" :rules="[rules.required, rules.min]"></v-text-field>
                    </v-col>
                  </v-row>
                </v-container>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="close">Cancel</v-btn>
                <v-btn color="blue darken-1" text @click="save">Save</v-btn>
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
        <v-icon small class="mr-2" @click="editItem(item)">mdi-pencil</v-icon>
        <v-icon small class="mr-2" @click="deleteItem(item)">mdi-delete</v-icon>
        <v-icon small v-if="!item.waterMeterFactoryNumber" @click="registerNewWaterMeter(item)">mdi-speedometer</v-icon>
      </template>
      <template v-slot:no-data>
        <v-btn color="primary" @click="initialize">Reset</v-btn>
      </template>
    </v-data-table>
    <v-card
      elevation="8"
      outlined
      shaped
      class="card"
    >
      <v-card-title>Max / Min consumption by house</v-card-title>
      <v-card-text>
        <div>
          <b>Top consumption house:</b> {{ maxMeterReadingHouse.address }}, <b>Reading:</b> {{ maxMeterReadingHouse.waterMeterReading }}
          <v-btn icon color="green" @click="loadMaxMeterReadingHouse"><v-icon>mdi-cached</v-icon></v-btn>
        </div>
        <div>
          <b>Min consumption house:</b> {{ minMeterReadingHouse.address }}, <b>Reading:</b> {{ minMeterReadingHouse.waterMeterReading }}
          <v-btn icon color="green" @click="loadMinMeterReadingHouse"><v-icon>mdi-cached</v-icon></v-btn>
        </div>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import axios from "axios";
    import { HouseSummary } from "../models/HouseSummary";
    import { ReadingAdd } from "../models/ReadingAdd";
    import { WaterMeterAdd } from "../models/WaterMeterAdd";
    
    @Component
    export default class House extends Vue {      
        houses: HouseSummary[] = [];
        editedItem: HouseSummary = {} as HouseSummary;
        defaultItem: HouseSummary = {} as HouseSummary;
        maxMeterReadingHouse: HouseSummary = {} as HouseSummary;
        minMeterReadingHouse: HouseSummary = {} as HouseSummary;

        readingItem: ReadingAdd = {} as ReadingAdd;
        readingDefaultItem: ReadingAdd = {} as ReadingAdd;

        waterMeterItem: WaterMeterAdd = {} as WaterMeterAdd;

        dialog = false;
        dialogDelete = false;
        dialogAddReading = false;
        dialogAddWaterMeter = false;
        
        editedIndex = -1;
        addReadingEditedIndex = -1;
        
        headers = [
            {
                text: "Id",
                sortable: false,
                value: "id"
            },
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
        
        rules = {
            required: (value: any) => !!value || "Required.",
            min: (v: string|any[]) => v?.length >= 3 || "Min 3 characters"
        }
        
        async created() {
            await this.initialize();
        }
        
        async initialize() {
            await this.loadHousesData();
            await this.loadMaxMeterReadingHouse();
            await this.loadMinMeterReadingHouse();
        }

        async loadHousesData() {
            this.houses = (await axios.get("/api/house/list")).data.result;
        }

        async loadMaxMeterReadingHouse() {
            this.maxMeterReadingHouse = (await axios.get("/api/house/getMaxMeter")).data.result;
        }

        async loadMinMeterReadingHouse() {
            this.minMeterReadingHouse = (await axios.get("/api/house/getMinMeter")).data.result;
        }
        
        get formTitle() {
            return this.editedIndex === -1 ? 'New House' : 'Edit House'
        }
        
        async editItem(item: HouseSummary) {
            this.editedIndex = this.houses.indexOf(item)
            this.editedItem = Object.assign({}, item)
            this.dialog = true
        }
        
        deleteItem(item: HouseSummary) {
            this.editedIndex = this.houses.indexOf(item)
            this.editedItem = Object.assign({}, item)
            this.dialogDelete = true
        }

        async registerNewWaterMeter(item: HouseSummary) {
            this.editedIndex = this.houses.indexOf(item);
            this.editedItem = Object.assign({}, item);
            this.dialogAddWaterMeter = true;
        }

        async registerNewWaterMeterSave(item: HouseSummary) {
            let input = new WaterMeterAdd();

            input.houseId = this.editedItem.id;
            input.factoryNumber = this.waterMeterItem.factoryNumber;
            input.reading = this.waterMeterItem.reading;
            
            let operationStatus = (await axios.post("/api/watermeter/add", input)).data.status;

            if (operationStatus !== 0) {
                // Notification
                return;
            }
            
            await this.loadHousesData();

            this.waterMeterItem = {} as WaterMeterAdd;

            this.dialogAddWaterMeter = false;
        }
        
        close() {
            this.dialog = false
            this.$nextTick(() => {
              this.editedItem = Object.assign({}, this.defaultItem)
              this.editedIndex = -1
            })
        }
        
        closeDelete() {
            this.dialogDelete = false;

            this.$nextTick(() => {
                this.editedItem = Object.assign({}, this.defaultItem)
                this.editedIndex = -1
            })
        }

        async deleteItemConfirm() {
            let operationStatus = (await axios.delete("/api/house/delete/" + this.editedItem.id)).data.status;

            if (operationStatus !== 0) {
                // Notification
                return;
            }

            this.houses.splice(this.editedIndex, 1)
            this.closeDelete()
        }
        
        async save() {
            if (this.editedIndex > -1) {
                let operationStatus = (await axios.put("/api/house/update", this.editedItem)).data.status;

                if (operationStatus !== 0) {
                    // Notification
                    return;
                }

                Object.assign(this.houses[this.editedIndex], this.editedItem)
            } else {
                let operationStatus = (await axios.post("/api/house/add", this.editedItem)).data.status;

                if (operationStatus !== 0) {
                    // Notification
                    return;
                }

                this.houses.push(this.editedItem)
            }
            
            this.close()
        }

        addReadingClose() {
            this.dialogAddReading = false;
            this.readingItem = new ReadingAdd();

            this.$nextTick(() => {
              this.addReadingEditedIndex = -1
            })
        }

        async addReadingSave() {
            let operationStatus = 1;
            let url = "/api/watermeter/";
            
            let input = new WaterMeterAdd();

            let isNum = /^\d+$/.test(this.readingItem.identifier);

            if (isNum) {
                url = url + "addreadingbyhouseid";

                input.houseId = parseInt(this.readingItem.identifier);
                input.reading = this.readingItem.reading;
            } else {
                url = url + "addReadingByFactoryNumber";

                input.factoryNumber = this.readingItem.identifier;
                input.reading = this.readingItem.reading;
            }
            
            operationStatus = (await axios.put(url, input)).data.status;

            if (operationStatus !== 0) {
                // Notification
                return;
            }

            await this.loadHousesData();

            this.addReadingClose();
        }
    }
</script>

<style scoped>
    .card {
        margin-top: 50px;
    }
</style>
