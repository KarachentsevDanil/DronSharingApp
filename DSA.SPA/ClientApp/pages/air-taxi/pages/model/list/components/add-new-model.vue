<template>
    <!-- Primary modal -->
    <div id="addTaxiModel" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Company</h4>
                </div>

                <div class="modal-body">
                    <div class="form-group">
                        <label>Name: </label>
                        <input v-model="name" class="form-control" placeholder="Model Name..."/>
                    </div>
                    <div class="form-group">
                      <label>Company: </label>
                      <select2 style="width: 100%;"
                             :configuration="companySelectConfiguration"
                             :options="companies"
                             v-model="taxiCompanyId"></select2>
                    </div>
                     <div class="form-group">
                      <label>Taxi Type: </label>
                      <select2 style="width: 100%;"
                             :configuration="typeSelectConfiguration"
                             :options="types"
                             v-model="taxiTypeId"></select2>
                    </div>
                    <div class="form-group">
                        <label>Description: </label>
                        <textarea cols="5" rows="5" v-model="description" class="form-control" placeholder="Description...">
                        </textarea>
                    </div>
                    <div class="form-group">
                        <label>Capacity: </label>
                        <input v-model="capacity" type="number" class="form-control" placeholder="Capacity..."/>
                    </div>
                    <div class="form-group">
                        <label>Maximum Range Flight(KM): </label>
                        <input v-model="maximumRangeFlight" type="number" class="form-control" placeholder="Maximum Range..."/>
                    </div>
                </div>

                <div class="modal-footer">
                    <button @click="addTaxiModel" type="button" :disabled="!name || capacity == 0 || maximumRangeFlight == 0" class="btn btn-primary">Add</button>
                    <button type="button" class="btn btn-link close-add-popup" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- /primary modal -->
</template>

<script>
import * as taxiModelService from "../../api/taxi-model-service";

const iconFormat = el => {
  return el.text;
};

export default {
  data() {
    return {
      companySelectConfiguration: {
        placeholder: "Select a company...",
        minimumInputLength: 2,
        templateResult: iconFormat,
        templateSelection: iconFormat,
        escapeMarkup: function(m) {
          return m;
        }
      },
      typeSelectConfiguration: {
        placeholder: "Select a type...",
        templateResult: iconFormat,
        minimumInputLength: 2,
        templateSelection: iconFormat,
        escapeMarkup: function(m) {
          return m;
        }
      },
      name: "",
      taxiCompanyId: null,
      taxiTypeId: null,
      description: "",
      capacity: 0,
      maximumRangeFlight: 0,
      companies: [],
      types: []
    };
  },
  async beforeMount() {
    let companies = (await taxiModelService.getAirTaxiCompanies()).data.Data;
    let types = (await taxiModelService.getAirTaxiTypes()).data.Data;

    this.companies = companies.map(el => ({
      id: el.AirTaxiCompanyId,
      text: el.Name
    }));

    this.types = types.map(el => ({
      id: el.AirTaxiTypeId,
      text: el.Name
    }));

    this.taxiCompanyId = this.companies[0].id;
    this.taxiTypeId = this.types[0].id;
  },
  methods: {
    clearForm() {
      this.name = "";
      this.taxiCompanyId = null;
      this.taxiTypeId = null;
      this.description = "";
      this.capacity = 0;
      this.maximumRangeFlight = 0;
    },
    async addTaxiModel() {
      let data = {
        airTaxiCompanyId: this.taxiCompanyId,
        airTaxiTypeId: this.taxiTypeId,
        description: this.description,
        capacity: this.capacity,
        maximumRangeFlight: this.maximumRangeFlight,
        name: this.name
      };

      await taxiModelService.addTaxiModel(data);

      $(".close-add-popup").click();

      this.clearForm();
      this.$noty.success("Taxi model was successfully added.");

      this.refreshTaxiModelsList();
    }
  },
  props: {
    refreshTaxiModelsList: {
      type: Function
    }
  }
};
</script>

<style>
#addNewAppointment .modal-footer {
  padding: 15px;
}
</style>