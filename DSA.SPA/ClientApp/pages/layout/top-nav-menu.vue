<template>
    <div class="navbar navbar-default header-highlight">
        <div class="navbar-header">
            <router-link class="navbar-brand" to="residents"><img src="../../assets/limitless/images/logo_light.png" alt=""></router-link>

            <ul class="nav navbar-nav visible-xs-block">
                <li><a data-toggle="collapse" data-target="#navbar-mobile" class="legitRipple"><i class="icon-tree5"></i></a></li>
                <li><a class="sidebar-mobile-main-toggle legitRipple"><i class="icon-paragraph-justify3"></i></a></li>
            </ul>
        </div>

        <div class="navbar-collapse collapse" id="navbar-mobile">
            <ul class="nav navbar-nav">
                <li><a class="sidebar-control sidebar-main-toggle hidden-xs legitRipple"><i class="icon-paragraph-justify3"></i></a></li>
            </ul>
        </div>
    </div>
</template>

<script>
export default {
  data() {
    return {
      
    };
  }
};
</script>