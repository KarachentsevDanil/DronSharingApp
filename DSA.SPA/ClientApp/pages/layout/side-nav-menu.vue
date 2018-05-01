<template>
    <div class="sidebar sidebar-main">
        <div class="sidebar-content">
            <!-- User menu -->
            <div class="sidebar-user-material">
                <div class="category-content">
                    <div class="sidebar-user-material-content">
                        <a href="#" :class="{'btn bg-teal-400 btn-rounded btn-icon btn-xs':!user.photo}" class="legitRipple">
                            <img v-if="user.photo" :src="user.photo" class="img-circle img-xs">
                            <span v-else>
                                {{user.icon}}
                            </span>
                        </a>
                        <h6 class="user-name">{{user.name}}</h6>
                        <span class="text-size-small">{{user.email}}</span>
                    </div>

                    <div class="sidebar-user-material-menu">
                        <a href="#user-nav" data-toggle="collapse" class="legitRipple"><span>My Account</span> <i class="caret"></i></a>
                    </div>
                </div>

                <div class="navigation-wrapper collapse" id="user-nav">
                    <ul class="navigation">
                        <li>
                            <router-link active-class="active" class="legitRipple" :to="'/user-profile'">
                                <i class="icon-user6"></i>
                                <span>My Profile</span>
                            </router-link>
                        </li>
                        <!-- <li>
                            <router-link active-class="active" class="legitRipple" :to="'/messages'">
                                <i class="icon-bubbles5"></i>
                                <span>
                                    <span class="badge bg-teal-400 pull-right">58</span> Messages
                                </span>
                            </router-link>
                        </li> -->
                        <li class="divider"></li>
                        <li>
                            <a href="#" class="legitRipple" v-on:click="logout">
                                <i class="icon-exit"></i>
                                <span>Logout</span>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="sidebar-category sidebar-category-visible">
                <div class="category-content no-padding">
                    <ul class="navigation navigation-main navigation-accordion">
                        <li class="navigation-header"><span>Air Taxi Sharing Portal</span> <i class="icon-menu" title="" data-original-title="Main pages"></i></li>
                        <li :class="{'active': isPanelActive(item)}" v-for="item in airTaxiItems" :key="item.title">
                            <router-link active-class="active" :class="{'legitRipple':true,'has-ul':item.children.length}" :to="item.url">
                                <i :class="[item.icon]"></i>
                                <span>
                                    {{item.title}}
                                </span>
                            </router-link>
                            <ul v-if="item.children.length">
                                <li v-for="child in item.children" :key="child.title">
                                    <router-link active-class="active" class="legitRipple" :to="child.url">
                                        {{child.title}}
                                    </router-link>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
  data() {
    return {
      user: {
        name: "Daniel Karachentsev",
        email: "flyling0897@gmail.com",
        icon: "DK"
      },
      airTaxiItems: [
        {
          title: "Air Taxi",
          icon: "icon-users2",
          url: "",
          children: [
            {
              title: "Company List",
              url: "/companies"
            },
            {
              title: "Type List",
              url: "/taxi-types"
            },
            {
              title: "Model List",
              url: "/taxi-models"
            },
            {
              title: "Taxies List",
              url: "/taxies"
            }
          ]
        },
        {
          title: "Rents",
          icon: "icon-cog3",
          url: "",
          children: [
            {
              title: "Rent Taxi",
              url: "/rent-taxi"
            },
            {
              title: "Rents List",
              url: "/rent-list"
            }
          ]
        }
      ]
    };
  },
  methods: {
    isPanelActive(item) {
      let isActive = false;

      isActive = item.url == this.$route.path;

      if (isActive) {
        return true;
      }

      isActive = item.children.some(t => t.url == this.$route.path);

      return isActive;
    },
    logout: async function(event) {
      window.location.href = "/Account/Login";
    }
  }
  // props: {
  //     user: {
  //         type: Object
  //     }
  // }
};
</script>

<style>
.user-name {
  font-size: 15px;
}
</style>