<template>
<div class="has-detached-left">
  <div class="page-header">
					<div class="page-header-content">
						<div class="page-title">
							<h4><i class="icon-home2 position-left"></i> <span class="text-semibold">Rent a Taxi</span></h4>
						</div>

						<!-- <div class="heading-elements">
							<div class="heading-btn-group">
								<a href="#" class="btn btn-link btn-float text-size-small has-text"><i class="icon-bars-alt text-primary"></i><span>Statistics</span></a>
								<a href="#" class="btn btn-link btn-float text-size-small has-text"><i class="icon-calculator text-primary"></i> <span>Invoices</span></a>
								<a href="#" class="btn btn-link btn-float text-size-small has-text"><i class="icon-calendar5 text-primary"></i> <span>Schedule</span></a>
							</div>
						</div> -->
					</div>

					<div class="breadcrumb-line breadcrumb-line-component">
						<ul class="breadcrumb">
							<li><a><i class="icon-home2 position-left"></i> Rents</a></li>
							<li class="active">Rent taxi</li>
						</ul>
					</div>
				</div>
				<!-- /page header -->


				<!-- Content area -->
				<div class="content">

					<!-- Detached sidebar -->
					<div class="sidebar-detached">
						<div class="sidebar sidebar-default sidebar-separate">
							<div class="sidebar-content">

								<!-- Sidebar search -->
								<div class="panel panel-white">
									<div class="panel-heading">
										<div class="panel-title text-semibold">
											<i class="icon-search text-size-base position-left"></i>
											Filter
										</div>
									</div>

									<div class="panel-body">
										<div>
											<div class="form-group">
                      <label>Company: </label>
                      <select2 style="width: 100%;"
                             :configuration="companySelectConfiguration"
                             :options="companies"
                             v-model="selectedCompanies"></select2>
                    </div>
                     <div class="form-group">
                      <label>Taxi Type: </label>
                      <select2 style="width: 100%;"
                             :configuration="typeSelectConfiguration"
                             :options="types"
                             v-model="selectedTypes"></select2>
                    </div>
                    <div class="form-group">
                      <label>Taxi Models: </label>
                      <select2 style="width: 100%;"
                             :configuration="taxiModelSelectConfiguration"
                             :options="filterModels"
                             :disabled="!selectedCompanies.length"
                             v-model="selectedModels"></select2>
                    </div>
										<div class="form-group">
                      <label>Start Date: </label>
                      <datetime input-class="form-control" v-model="startDate"></datetime>
                    </div>
										<div class="form-group">
                      <label>End Date: </label>
                      <datetime input-class="form-control" v-model="endDate"></datetime>
                    </div>

											<button class="btn bg-blue btn-block" @click="filterTaxies">
												<i class="icon-search text-size-base position-left"></i>
												Find Taxies
											</button>
										</div>
									</div>
								</div>

							</div>
						</div>
					</div>
		            <!-- /detached sidebar -->


					<!-- Detached content -->
					<div class="container-detached">
						<div class="content-detached">
							<!-- Cards layout -->
							<ul class="media-list content-group">
								<li class="media panel panel-body stack-media-on-mobile" v-for="taxi in taxies" :key="taxi.AirTaxiId">
									<div class="media-left">
										<a href="#">
											<img v-if="taxi.AirTaxiPhoto" :src="taxi.AirTaxiPhoto" class="img-rounded img-lg icon-taxi-image" alt="">
											<img v-else src="../../../../assets/limitless/images/defaultCar.jpg" class="img-rounded img-lg icon-taxi-image" alt="">
										</a>
									</div>

									<div class="media-body">
										<h6 class="media-heading text-semibold">
											<router-link :to="'/taxi-details/'+taxi.AirTaxiId" >{{taxi.AirTaxiCompanyName}} {{taxi.AirTaxiModelName}} </router-link>
										</h6>

										<ul class="list-inline list-inline-separate text-muted mb-10">
											<li>
                        <router-link :to="'/taxi-details/'+taxi.AirTaxiId" class="text-muted">{{taxi.AirTaxiCompanyName}} {{taxi.AirTaxiModelName}}</router-link>
                      </li>
											<li>{{taxi.AirTaxiTypeName}}</li>
                      <li>${{taxi.DailyCosts}} per day.</li>
										</ul>
										{{taxi.AirTaxiDescription}}
									</div>

									<div class="media-right text-nowrap">
										<span class="label bg-blue" >Rent a taxi</span>
									</div>
								</li>
							</ul>
							<!-- /cards layout -->


							<!-- Pagination -->
              <div class="text-center content-group-lg pt-20">
								<pagination :currentPage="filters.pagination.currentPage" :total="filters.pagination.total" :page-size="filters.pagination.pageSize" :callback="pageChanged" :options="filters.pagination.paginationOptions" nav-class="padding-10" ul-class="bg-color-red" li-class="txt-color-blue">
                </pagination>
							</div>
							 
							<!-- /pagination -->

						</div>
					</div>

				</div>
</div>
</template>

<script>
import * as taxiService from "../../../air-taxi/pages/taxi/api/taxi-service";

const iconFormat = el => {
  return el.text;
};

export default {
  data() {
    return {
      taxies: [],
      types: [],
      companies: [],
      models: [],
      loadedModels: [],
      selectedTypes: [],
      selectedCompanies: [],
      selectedModels: [],
      startDate: "",
      endDate: "",
      companySelectConfiguration: {
        placeholder: "Select a companies...",
        multiple: true,
        templateResult: iconFormat,
        templateSelection: iconFormat,
        escapeMarkup: function(m) {
          return m;
        }
      },
      typeSelectConfiguration: {
        placeholder: "Select a types...",
        multiple: true,
        templateResult: iconFormat,
        templateSelection: iconFormat,
        escapeMarkup: function(m) {
          return m;
        }
      },
      taxiModelSelectConfiguration: {
        placeholder: "Select a models...",
        multiple: true,
        templateResult: iconFormat,
        templateSelection: iconFormat,
        escapeMarkup: function(m) {
          return m;
        }
      },
      filters: {
        isApply: false,
        title: "",
        pagination: {
          total: 0,
          pageSize: 10,
          currentPage: 1,
          paginationOptions: {
            offset: 3,
            previousText: "Prev",
            nextText: "Next",
            alwaysShowPrevNext: true
          }
        }
      }
    };
  },
  methods: {
    async pageChanged(page) {
      this.filters.pagination.currentPage = page;
      await this.getTaxies();
    },
    async getTaxies() {
      let params = {
        skip:
          this.filters.pagination.pageSize *
          (this.filters.pagination.currentPage - 1),
        take: this.filters.pagination.pageSize
      };

      let data = (await taxiService.getTaxiesByParams(params)).data.Data;

      this.taxies = data.Collection;
      this.filters.pagination.total = data.TotalCount;
    },
    async filterTaxies() {
      this.filters.pagination.currentPage = 1;

      let params = {
        skip:
          this.filters.pagination.pageSize *
          (this.filters.pagination.currentPage - 1),
        take: this.filters.pagination.pageSize,
        selectedTypeIds: this.selectedTypes,
        selectedCompanyIds: this.selectedCompanies,
        selectedModelIds: this.selectedModels,
        startDate: this.startDate,
        endDate: this.endDate
      };

      let data = (await taxiService.getTaxiesByParams(params)).data.Data;

      this.taxies = data.Collection;
      this.filters.pagination.total = data.TotalCount;
    }
  },
  computed: {
    filterModels() {
      if (this.selectedCompanies.length) {
        let models = this.loadedModels
          .filter(
            el =>
              this.selectedCompanies.some(id => id == el.AirTaxiCompanyId) &&
              (!this.selectedTypes.length ||
                this.selectedTypes.some(id => id == el.AirTaxiTypeId))
          )
          .map(el => ({
            id: el.AirTaxiModelId,
            text: el.Name
          }));

        return models;
      }

      return [];
    }
  },
  async beforeMount() {
    let companies = (await taxiService.getAirTaxiCompanies()).data.Data;
    let types = (await taxiService.getAirTaxiTypes()).data.Data;
    this.loadedModels = (await taxiService.getAirTaxiModels()).data.Data;

    this.companies = companies.map(el => ({
      id: el.AirTaxiCompanyId,
      text: el.Name
    }));

    this.types = types.map(el => ({
      id: el.AirTaxiTypeId,
      text: el.Name
    }));

    await this.getTaxies();
  }
};
</script>

<style>
.icon-taxi-image {
  width: 130px !important;
  height: 100px !important;
}
</style>
