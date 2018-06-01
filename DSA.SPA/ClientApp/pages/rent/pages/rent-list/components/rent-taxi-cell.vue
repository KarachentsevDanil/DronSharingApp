<template>
    <div>
        <td>
            <div class="media-left media-top">
                <a class="legitRipple">
                    <img v-if="row.AirTaxiPhoto" :src="row.AirTaxiPhoto" class="img-rounded icon-photo">
                    <img v-else src="../../../../../assets/limitless/images/defaultCar.jpg" class="img-rounded icon-photo">
                </a>
            </div>
            <div class="media-body">
                <span class="display-inline-block text-semibold letter-icon-title">{{row.AirTaxiCompany}} {{row.AirTaxiModel}}</span>
                <div class="text-muted text-size-small">
                    <span><span v-localize="{i: 'taxi.taxiType'}"></span> {{row.AirTaxiType}}</span>
                    <br>                   
                    <span><span v-localize="{i: 'taxi.pricePerDay'}"></span> {{row.AirTaxiDailyCosts}}</span>
                </div>
            </div>
        </td>
    </div>
</template>

<script>
export default {
  props: ["row", "xprops"],
};
</script>

<style>
.icon-photo{
    width: 70px !important;
    height: 50px !important;
}
</style>
