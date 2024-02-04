"use client";

import Link from "next/link";
import clsx from "clsx";
import React from "react";
import { usePathname } from "next/navigation";
import { MagnifyingGlassIcon } from "@radix-ui/react-icons";

type Props = {};

export const Navbar = (props: Props) => {
  const pathname = usePathname();

  const [summonerName, setSummonerName] = React.useState("");
  const [summonerNameError, setSummonerNameError] = React.useState("");
  const summonerNameRegex = new RegExp(".+#.+", "g");

  const [server, setServer] = React.useState("NA1");

  const [isFocused, setIsFocused] = React.useState(false);

  const handleSummonerSearch = () => {
    if (summonerNameRegex.test(summonerName)) {
      console.log("Search for summoner: ", summonerName);
    } else {
      console.log("Invalid summoner name");
    }
  };

  return (
    <div className="w-full h-20">
      <nav className="flex items-center justify-between h-full px-8 max-w-[90rem] mx-auto">
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
          <div className="h-full relative group">
            <div className="flex items-center h-full cursor-default">
              <div className="flex border border-leagueGold-500/35 divide-x divide-leagueGold-500/35">
                <select
                  onFocus={() => setIsFocused(true)}
                  onBlur={() => setIsFocused(false)}
                  tabIndex={1}
                  className="bg-transparent text-text-primary px-2 focus:outline-leagueGold-400 focus:border-leagueGold-400 focus:shadow-leagueGold-400"
                  onChange={(e) => setServer(e.target.value)}
                  value={server}
                >
                  <option value="NA1">NA</option>
                  <option value="EUW1">EUW</option>
                  <option value="EUN1">EUNE</option>
                  <option value="KR">KR</option>
                  <option value="JP1">JP</option>
                  <option value="BR1">BR</option>
                  <option value="LA1">LAN</option>
                  <option value="RU">RU</option>
                  <option value="TR1">TR</option>
                  <option value="OC1">OCE</option>
                  {/* TODO: add remaining servers */}
                </select>
                <input
                  onFocus={() => setIsFocused(true)}
                  onBlur={() => setIsFocused(false)}
                  tabIndex={2}
                  type="text"
                  placeholder="Search for a Summoner"
                  value={summonerName}
                  onChange={(e) => setSummonerName(e.target.value)}
                  className="bg-transparent p-4 text-text-primary placeholder:text-text-primary/75 focus:outline-leagueGold-400 focus:border-leagueGold-400 focus:shadow-leagueGold-400"
                />
                <button
                  onFocus={() => setIsFocused(true)}
                  onBlur={() => setIsFocused(false)}
                  tabIndex={3}
                  className="p-4 group/button hover:bg-gradient-to-t from-leagueGray-100/25 to-leagueGray-hextech-black to-55%"
                  onClick={handleSummonerSearch}
                >
                  <MagnifyingGlassIcon className="w-6 h-6 text-text-primary/75 group-hover/button:text-text-primary" />
                </button>
              </div>
            </div>
            <div
              className={clsx(
                `absolute w-full h-96 top-full border border-leagueGold-500/35`,
                isFocused ? "flex" : "hidden"
              )}
            ></div>
          </div>
        </ul>
      </nav>
      <hr className="w-full h-[0.5px] bg-leagueGold-500 opacity-35" />
    </div>
  );
};
