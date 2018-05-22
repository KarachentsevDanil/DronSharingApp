<template>
    <!-- Primary modal -->
    <div id="rentTaxi" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Rent a taxi</h4>
                </div>

                <div class="modal-body">
                    <div class="form-horizontal">
                            <div class="form-group">
                                <label class="col-sm-2 control-label">Owner: </label>
                                <div class="col-sm-10">
                                    <p class="form-control-static">{{taxi.CustomerName}}</p>
                                </div>
                            </div>
                            <div class="form-group">
                                    <label class="col-sm-2 control-label">Taxi: </label>
                                    <div class="col-sm-10">
                                        <p class="form-control-static">{{taxi.AirTaxiId}} - {{taxi.AirTaxiCompanyName}} {{taxi.AirTaxiModelName}}</p>
                                    </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">Start Date: </label>
                                <div class="col-sm-10">
                                    <datetime input-class="form-control" v-model="startDate"></datetime>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label">End Date: </label>
                                <div class="col-sm-10">
                                    <datetime input-class="form-control" v-model="endDate"></datetime>
                                </div>
                            </div>
                    </div>

                </div>

                <div class="modal-footer">
                    <button @click="rentTaxi" type="button" :disabled="!this.startDate || !this.endDate" class="btn btn-primary">Rent</button>
                    <button type="button" class="btn btn-link close-add-popup" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- /primary modal -->
</template>

<script>
import * as rentService from "../../api/rent-service";

import * as authGetters from "../../../auth/store/types/getter-types";
import * as authResources from "../../../auth/store/resources";

import { mapGetters } from "vuex";

export default {
  data() {
    return {
      startDate: null,
      endDate: null
    };
  },
  methods: {
    clearForm() {
      this.startDate = null;
      this.endDate = null;
    },
    async rentTaxi() {
      let data = {
        customerId: this.CustomerId,
        airTaxiId: this.taxi.AirTaxiId,
        startDate: this.startDate,
        endDate: this.endDate
      };

      let result = (await rentService.addRent(data)).data;
      if (this.result) {
        $(".close-add-popup").click();
        this.clearForm();
        this.$noty.success("Rent has successfully added.");
        this.added();
      }else{
        this.$noty.error("Try to find another date range for rent, you can check calendar to find free date range.");          
      }
    }
  },
  computed: {
    ...mapGetters({
      getUser: authResources.AUTH_STORE_NAMESPACE.concat(
        authGetters.GET_USER_GETTER
      )
    })
  },
  props: {
    added: {
      type: Function
    },
    taxi: {
      type: Object
    }
  }
};
</script>

<style>
#addNewAppointment .modal-footer {
  padding: 15px;
}
</style>