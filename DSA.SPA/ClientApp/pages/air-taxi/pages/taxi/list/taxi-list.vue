<template>
    <div>
        <div class="page-header">
            <div class="page-header-content">
                <div class="page-title">
                    <h4><i class="icon-users2 position-left"></i> <span class="text-semibold">Air Taxi List</span></h4>

                    <ul class="breadcrumb position-right">
                        <li><a>Air Taxies</a></li>
                        <li class="active">Air Taxi List</li>
                    </ul>
                    <a class="heading-elements-toggle"><i class="icon-more"></i></a><a class="heading-elements-toggle"><i class="icon-more"></i></a>
                </div>
                <div class="heading-elements">
                        <div class="heading-btn-group">
                            <a href="#" class="btn bg-blue btn-labeled heading-btn legitRipple" data-toggle="modal" data-target="#addAirTaxi">
                                <b><i class="icon-plus2"></i></b> Add Taxi
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
        <add-new-taxi :refreshAirTaxiList="getTaxies"/>
    </div>
</template>

<script>
import * as taxiService from "../api/taxi-service";

import taxiActionCell from "./components/taxi-action-cell";
import addNewTaxi from "./components/add-new-taxi";

import * as authGetters from "../../../../auth/store/types/getter-types";
import * as authResources from "../../../../auth/store/resources";

import { mapGetters } from "vuex";

import Vue from "Vue";

export default {
  components: {
    taxiActionCell: taxiActionCell,
    addNewTaxi: addNewTaxi
  },
  data: () => ({
    tblClass: "grid-table",
    pageSizeOptions: [10, 25, 50, 100],
    columns: [
      {
        title: "Owner",
        field: "CustomerName",
        sortable: false
      },
      {
        title: "Model Name",
        field: "AirTaxiModelName",
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
        title: "Daily Costs",
        field: "DailyCosts",
        sortable: false
      },
      {
        title: "Actions",
        tdComp: "taxiActionCell",
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
        await this.getTaxies();
      },
      deep: true
    }
  },
  computed: {
    ...mapGetters({
      getUser: authResources.AUTH_STORE_NAMESPACE.concat(
        authGetters.GET_USER_GETTER
      )
    })
  },
  methods: {
    async getTaxies() {
      let params = {
        skip: this.query.offset,
        take: this.query.limit
      };

      if (this.getUser.Role == "User") {
        params.customerId = this.getUser.CustomerId;
      }

      let data = (await taxiService.getTaxiesByParams(params)).data.Data;

      this.data = data.Collection;
      this.total = data.TotalCount;
    }
  }
};
</script>