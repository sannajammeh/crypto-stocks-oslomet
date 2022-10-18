// @ts-check
/** @type {import('vite').UserConfig} */
export default {
  server: {
    port: 3000,
    hmr: {
      protocol: "ws",
    },
  },
  build: {
    outDir: "../wwwroot",
  },
};
