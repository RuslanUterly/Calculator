import React from "react";

export default function Expression() {
  return (
    <section className="mx-auto w-96 bg-slate-200 rounded-xl">
      <div className="flex flex-col py-8 px-8 gap-4">
        <input 
            className="block px-4 py-2 rounded-xl"
            type="text" 
            placeholder="Введите выражение" 
            />
        <button className="py-2 items-start w-32 text-white text-lg bg-slate-400 rounded-xl">Расчет</button>
      </div>
    </section>
  );
}
