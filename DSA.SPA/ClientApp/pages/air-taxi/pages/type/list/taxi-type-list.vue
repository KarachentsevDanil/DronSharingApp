<template>
    <div>
        <div class="page-header">
            <div class="page-header-content">
                <div class="page-title">
                    <h4><i class="icon-users2 position-left"></i> <span class="text-semibold">Taxi Type List</span></h4>

                    <ul class="breadcrumb position-right">
                        <li><a>Air Taxies</a></li>
                        <li class="active">Taxi Type List</li>
                    </ul>
                    <a class="heading-elements-toggle"><i class="icon-more"></i></a><a class="heading-elements-toggle"><i class="icon-more"></i></a>
                </div>
                <div class="heading-elements">
                        <div class="heading-btn-group">
                            <a href="#" class="btn bg-blue btn-labeled heading-btn legitRipple" data-toggle="modal" data-target="#addTaxiType">
                                <b><i class="icon-plus2"></i></b> Add Taxi Type
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
        <add-new-type :refreshTypeList="getTaxiTypes"/>
    </div>
</template>

<script>
import * as taxiTypeService from "../api/taxi-type-service";

import typeActionCell from "./components/type-action-cell";
import addNewType from './components/add-new-type';

import Vue from "Vue";

export default {
  components: {
    typeActionCell: typeActionCell,
    addNewType: addNewType
  },
  data: () => ({
    tblClass: "grid-table",
    pageSizeOptions: [10, 25, 50, 100],
    columns: [
      {
        title: "Id",
        field: "AirTaxiTypeId",
        sortable: false,
        tdStyle: { width: "10%" }
      },
      {
        title: "Taxi Type Name",
        field: "Name",
        sortable: false,
        tdStyle: { width: "50%" }
      },
      {
        title: "Actions",
        tdComp: "typeActionCell",
        thStyle: { textAlign: "center" },
        tdStyle: { width: "40%" }
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
        await this.getTaxiTypes();
      },
      deep: true
    }
  },
  methods: {
    async getTaxiTypes() {
      let params = {
        skip: this.query.offset,
        take: this.query.limit
      };

      let data = (await taxiTypeService.getTaxiTypesByParams(params)).data.Data;

      this.data = data.Collection;
      this.total = data.TotalCount;
    }
  }
};
</script>