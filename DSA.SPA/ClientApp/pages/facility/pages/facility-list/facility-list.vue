<template>
    <div>
        <div class="page-header">
            <div class="page-header-content">
                <div class="page-title">
                    <h4><i class="icon-users2 position-left"></i> <span class="text-semibold">Facility List</span></h4>

                    <ul class="breadcrumb position-right">
                        <li class="active">Facility List</li>
                    </ul>
                    <a class="heading-elements-toggle"><i class="icon-more"></i></a><a class="heading-elements-toggle"><i class="icon-more"></i></a>
                </div>
                <div class="heading-elements">
                        <div class="heading-btn-group">
                            <a href="#" class="btn bg-blue btn-labeled heading-btn legitRipple" data-toggle="modal" data-target="#addFacility">
                                <b><i class="icon-plus2"></i></b> Add Facility
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
        <add-new-facility :refreshList="getFacilities"/>
    </div>
</template>

<script>
import * as facilityService from "../../api/facility-service";

import addNewFacility from './components/add-new-facility';

import Vue from "Vue";

export default {
  components: {
    addNewFacility: addNewFacility
  },
  data: () => ({
    tblClass: "grid-table",
    pageSizeOptions: [10, 25, 50, 100],
    columns: [
      {
        title: "Id",
        field: "FacilityId",
        sortable: false
      },
      {
        title: "Name",
        field: "Name",
        sortable: false
      },
      {
        title: "Address",
        field: "Address",
        sortable: false
      },
      {
        title: "Email",
        field: "Email",
        sortable: false
      },
      {
        title: "Phone",
        field: "Phone"
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
        await this.getFacilities();
      },
      deep: true
    }
  },
  methods: {
    async getFacilities() {
      let params = {
        skip: this.query.offset,
        take: this.query.limit
      };

      let data = (await facilityService.getFacilities(params)).data.Data;

      this.data = data.Collection;
      this.total = data.TotalCount;
    }
  }
};
</script>