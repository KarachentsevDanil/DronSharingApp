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
										<form action="#">
											<div class="form-group">
												<div class="has-feedback has-feedback-left">
													<input type="search" class="form-control" placeholder="Model name or keywords">
													<div class="form-control-feedback">
														<i class="icon-reading text-size-large text-muted"></i>
													</div>
												</div>
											</div>

											<button type="submit" class="btn bg-blue btn-block">
												<i class="icon-search text-size-base position-left"></i>
												Find Taxies
											</button>
										</form>
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
											<img src="../../../../assets/limitless/images/cover.jpg" class="img-rounded img-lg" alt="">
										</a>
									</div>

									<div class="media-body">
										<h6 class="media-heading text-semibold">
											<a href="#">{{taxi.AirTaxiCompanyName}} {{taxi.AirTaxiModelName}}</a>
										</h6>

										<ul class="list-inline list-inline-separate text-muted mb-10">
											<li><a href="#" class="text-muted">{{taxi.AirTaxiCompanyName}} {{taxi.AirTaxiModelName}}</a></li>
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
export default {
  data() {
    return {
      taxies: [],
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
    }
  },
  async beforeMount() {
    await this.getTaxies();
  }
};
</script>
