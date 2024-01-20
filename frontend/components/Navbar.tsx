"use client";

import React from "react";

type Props = {};

export const Navbar = (props: Props) => {
  return (
    <div className="w-full h-20">
      <nav className="flex items-center justify-between h-full px-8 max-w-[90rem]"></nav>
      <hr className="w-full h-[0.5px] bg-leagueGold-500 opacity-35" />
    </div>
  );
};
