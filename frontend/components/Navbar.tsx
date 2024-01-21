"use client";

import Link from "next/link";
import clsx from "clsx";
import React from "react";
import { usePathname } from "next/navigation";

type Props = {};

export const Navbar = (props: Props) => {
  const pathname = usePathname();
  console.log(pathname);

  return (
    <div className="w-full h-20">
      <nav className="flex items-center justify-between h-full px-8 max-w-[90rem]">
        <ul className="flex h-full items-center">
          <li className="flex items-center px-4 h-full group hover:bg-gradient-to-t from-leagueGray-100/25 to-leagueGray-hextech-black to-55%">
            <p className="text-2xl font-bold text-text-primary/75 group-hover:text-text-primary">
              League Stats
            </p>
          </li>
        </ul>
        <ul className="h-full flex space-x-[0.6px]">
          <Link
            href="/"
            className={clsx("h-full", pathname === "/" ? `cursor-default` : "")}
          >
            <li
              className={clsx(
                `flex items-center px-4 h-full group hover:bg-gradient-to-t from-leagueGray-100/25 to-leagueGray-hextech-black to-55%`,
                pathname === "/"
                  ? `bg-gradient-to-t from-leagueGray-100/25 to-leagueGray-hextech-black to-55% `
                  : ""
              )}
            >
              <p
                className={clsx(
                  `text-2xl font-bold group-hover:text-text-primary`,
                  pathname === "/"
                    ? `text-text-primary`
                    : `text-text-primary/75`
                )}
              >
                Home
              </p>
            </li>
          </Link>
          <Link
            href="/champions"
            className={clsx(
              "h-full",
              pathname === "/champions" ? `cursor-default` : ""
            )}
          >
            <li
              className={clsx(
                `flex items-center px-4 h-full group hover:bg-gradient-to-t from-leagueGray-100/25 to-leagueGray-hextech-black to-55%`,
                pathname === "/champions"
                  ? `bg-gradient-to-t from-leagueGray-100/25 to-leagueGray-hextech-black to-55% `
                  : ""
              )}
            >
              <p
                className={clsx(
                  `text-2xl font-bold group-hover:text-text-primary`,
                  pathname === "/champions"
                    ? `text-text-primary`
                    : `text-text-primary/75`
                )}
              >
                Champions
              </p>
            </li>
          </Link>
        </ul>
      </nav>
      <hr className="w-full h-[0.5px] bg-leagueGold-500 opacity-35" />
    </div>
  );
};
