import React, { useState } from "react";
import { NavLink, useLocation } from "react-router-dom";

export default function NavBar() {
  const location = useLocation();

  return (
    <nav className="w-96 mx-auto mt-8 bg-slate-200 rounded-xl">
      <ul className="flex justify-between p-4">
        <li>
          <NavLink
            to="/"
            className={`px-5 py-2 rounded-xl ${
              location.pathname === "/" ? "bg-slate-400" : ""
            }`}
          >
            Базовые операции
          </NavLink>
        </li>
        <li>
          <NavLink
            to="/expression"
            className={`px-5 py-2 rounded-xl ${
              location.pathname === "/expression" ? "bg-slate-400" : ""
            }`}
          >
            Выражение
          </NavLink>
        </li>
      </ul>
    </nav>
  );
}
