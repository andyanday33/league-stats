import type { Config } from "tailwindcss";

const config: Config = {
  content: [
    "./pages/**/*.{js,ts,jsx,tsx,mdx}",
    "./components/**/*.{js,ts,jsx,tsx,mdx}",
    "./app/**/*.{js,ts,jsx,tsx,mdx}",
  ],
  theme: {
    extend: {
      backgroundImage: {
        "gradient-radial": "radial-gradient(var(--tw-gradient-stops))",
        "gradient-conic":
          "conic-gradient(from 180deg at 50% 50%, var(--tw-gradient-stops))",
      },
      colors: {
        text: {
          primary: "#F0E6D2",
          hover: "#A09B8C",
        },
        leagueBlue: {
          "100": "#CDFAFA",
          "150": "#010a13",
          "200": "#0AC8B9",
          "300": "#0397AB",
          "400": "#005A82",
          "500": "#0A323C",
          "600": "#091428",
          "700": "#0A1428",
        },
        leagueGold: {
          "100": "#F0E6D2",
          "200": "#C8AA6E",
          "300": "#C8AA6E",
          "400": "#C89B3C",
          "500": "#785A28",
          "600": "#463714",
          "700": "#32281E",
        },
        leagueGray: {
          "100": "#A09B8C",
          "150": "#5B5A56",
          "200": "#3C3C41",
          "300": "#1E2328",
          cool: "#1E282D",
          "hextech-black": "#010A13",
        },
      },
    },
  },
  plugins: [],
};
export default config;
