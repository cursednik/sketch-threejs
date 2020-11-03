precision highp float;

uniform float time;
uniform sampler2D prevVelocity;
uniform sampler2D velocity;
uniform sampler2D acceleration;
uniform sampler2D noiseTex;
uniform sampler2D delay;
uniform sampler2D mass;

varying vec2 vUv;

#pragma glslify: drag = require(glsl-force/drag)
#pragma glslify: hook = require(glsl-force/hook);

void main(void) {
  vec3 pv = texture2D(prevVelocity, vUv).xyz;
  vec3 v = texture2D(velocity, vUv).xyz;
  vec3 a = texture2D(acceleration, vUv).xyz;
  float mass = texture2D(mass, vUv).x;
  vec3 d = drag(a, 0.2);
  vec3 h = hook(v, pv, 0.6, 0.07);

  gl_FragColor = vec4(a + d + h, 1.0);
}
