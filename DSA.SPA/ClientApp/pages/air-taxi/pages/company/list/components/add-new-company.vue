<template>
    <div id="addCompany" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-primary">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Add Company</h4>
                </div>

                <div class="modal-body">
                    <div class="form-group">
							<label>Name: </label>
							<input v-model="name" class="form-control" placeholder="Company Name..."/>
					</div>
                </div>

                <div class="modal-footer">
                    <button @click="addCompany" type="button" :disabled="!this.name" class="btn btn-primary">Add</button>
                    <button type="button" class="btn btn-link close-add-popup" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import * as companyService from "../../api/company-service";

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
    async addCompany() {
      let data = {
        name: this.name
      };

      await companyService.addCompany(data);

      $(".close-add-popup").click();
      
      this.clearForm();
      this.$noty.success("Company was successfully added.");

      this.refreshCompanyList();
    }
  },
  props: {
    refreshCompanyList: {
      type: Function
    }
  }
};
</script>