Shader "Custom/StencilMask" {
  Properties{
    _StencilMask("Stencil mask", Int) = 0
  }

    SubShader{
      Tags {
        "RenderType" = "Opaque"
      }

      ColorMask 0
      ZWrite off

      Stencil {
        Ref[_StencilMask]
        Comp Never
        Fail Replace
      }

      Pass {}
  }
}