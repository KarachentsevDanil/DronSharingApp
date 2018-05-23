<template>
    <div>
        <div class="page-header">
            <div class="page-header-content">
                <div class="page-title">
                    <h4><i class="icon-users2 position-left"></i> <span class="text-semibold">Resident List</span></h4>

                    <ul class="breadcrumb position-right">
                        <li class="active">Resident List</li>
                    </ul>
                    <a class="heading-elements-toggle"><i class="icon-more"></i></a><a class="heading-elements-toggle"><i class="icon-more"></i></a>
                </div>
                <div class="heading-elements">
                        <div class="heading-btn-group">
                            <a href="#" class="btn bg-blue btn-labeled heading-btn legitRipple" data-toggle="modal" data-target="#addResident">
                                <b><i class="icon-plus2"></i></b> Add Resident
                            </a>
                        </div>
                </div>
            </div>
        </div>

        <div class="content">
            <div class="panel panel-flat without-header">
                <datatable v-bind="$data" :HeaderSettings="false" />
            </div>
        </div>
        <add-new-resident :refreshList="getResidents"/>
    </div>
</template>

<script>
import * as residentService from "../../api/resident-service";

import addNewResident from './components/add-new-resident';

import Vue from "Vue";

export default {
  components: {
    addNewResident: addNewResident
  },
  data: () => ({
    tblClass: "grid-table",
    pageSizeOptions: [10, 25, 50, 100],
    columns: [
      {
        title: "Id",
        field: "ResidentId",
        sortable: false
      },
      {
        title: "Name",
        field: "FullName",
        sortable: false
      },
      {
        title: "Facility",
        field: "FacilityName",
        sortable: false
      },
      {
        title: "BirthDay",
        field: "FormattedDate",
        sortable: false
      }
    ],
    data: [],
    total: 0,
    query: {},
    xprops: {
      eventbus: new Vue()
    }
  }),
  watch: {
    query: {
      async handler() {
        await this.getResidents();
      },
      deep: true
    }
  },
  methods: {
    async getResidents() {
      let params = {
        skip: this.query.offset,
        take: this.query.limit
      };

      let data = (await residentService.getResidents(params)).data.Data;

      this.data = data.Collection;
      this.total = data.TotalCount;
    }
  }
};
</script>