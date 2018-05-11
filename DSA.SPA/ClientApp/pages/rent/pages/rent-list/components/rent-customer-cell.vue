<template>
    <div>
        <td>
            <div class="media-left media-top">
                <span class="btn bg-pink-400 btn-rounded btn-icon btn-xs legitRipple">
                    <span class="letter-icon">{{getNameIncon()}}</span>
                </span>
            </div>
            <div class="media-body">
                <span class="display-inline-block text-semibold letter-icon-title">{{row.CustomerName}}</span>
                <div class="text-muted text-size-small">
                    <div><i class="icon-envelop2"></i> <a href="mailto:jdoe@engagesnf.com">{{row.CustomerEmail}}</a></div>
                </div>
            </div>
        </td>
    </div>
</template>

<script>
export default {
  props: ["row", "xprops"],
  methods: {
    getNameIncon() {
      let data = this.row.CustomerName;
      let icon = data.split(" ");

      if (icon.length > 1) {
        return icon[0][0] + icon[1][0];
      }

      return icon[0][0] + icon[0][1];
    }
  }
};
</script>