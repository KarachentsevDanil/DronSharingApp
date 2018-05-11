<template>
    <div>
        <div class="page-header">
            <div class="page-header-content">
                <div class="page-title">
                    <h4><i class="icon-users2 position-left"></i> <span class="text-semibold">Taxi Model List</span></h4>

                    <ul class="breadcrumb position-right">
                        <li><a>Air Taxies</a></li>
                        <li class="active">Taxi Model List</li>
                    </ul>
                    <a class="heading-elements-toggle"><i class="icon-more"></i></a><a class="heading-elements-toggle"><i class="icon-more"></i></a>
                </div>
                <div class="heading-elements">
                        <div class="heading-btn-group">
                            <a href="#" class="btn bg-blue btn-labeled heading-btn legitRipple" data-toggle="modal" data-target="#addTaxiModel">
                                <b><i class="icon-plus2"></i></b> Add Taxi Model
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
        <add-new-model :refreshTaxiModelsList="getTaxiModels"/>
    </div>
</template>

<script>
import * as taxiModelService from "../api/taxi-model-service";

import modelActionCell from "./components/model-action-cell";
import addNewModel from './components/add-new-model';

import Vue from "Vue";

export default {
  components: {
    modelActionCell: modelActionCell,
    addNewModel: addNewModel
  },
  data: () => ({
    tblClass: "grid-table",
    pageSizeOptions: [10, 25, 50, 100],
    columns: [
      {
        title: "Model Name",
        field: "Name",
        sortable: false
      },
      {
        title: "Company",
        field: "AirTaxiCompanyName",
        sortable: false
      },
      {
        title: "Type",
        field: "AirTaxiTypeName",
        sortable: false
      },
      {
        title: "Description",
        field: "Description",
        sortable: false
      },
      {
        title: "Actions",
        tdComp: "modelActionCell",
        thStyle: { textAlign: "center" }
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
        await this.getTaxiModels();
      },
      deep: true
    }
  },
  methods: {
    async getTaxiModels() {
      let params = {
        skip: this.query.offset,
        take: this.query.limit
      };

      let data = (await taxiModelService.getTaxiModelsByParams(params)).data.Data;

      this.data = data.Collection;
      this.total = data.TotalCount;
    }
  }
};
</script>