<template>
    <!-- Primary modal -->
    <div id="addTaxiType" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Taxi Type</h4>
                </div>

                <div class="modal-body">
                    <div class="form-group">
							<label>Name: </label>
							<input v-model="name" class="form-control" placeholder="Type Name..."/>
					</div>
                </div>

                <div class="modal-footer">
                    <button @click="addTaxiType" type="button" :disabled="!this.name" class="btn btn-primary">Add</button>
                    <button type="button" class="btn btn-link close-add-popup" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
    <!-- /primary modal -->
</template>

<script>
import * as taxiTypeService from "../../api/taxi-type-service";

export default {
  data() {
    return {
      name: ""
    };
  },
  methods: {
    clearForm() {
      this.name = "";
    },
    async addTaxiType() {
      let data = {
        name: this.name
      };

      await taxiTypeService.addTaxiType(data);

      $(".close-add-popup").click();
      
      this.clearForm();
      this.$noty.success("Taxi type was successfully added.");

      this.refreshTypeList();
    }
  },
  props: {
    refreshTypeList: {
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