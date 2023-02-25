import React, { useState } from "react";
import ArizaWrapper from "../style/ArizaWrapper";
import logo from "../img/metsenatclub.svg";
import { Link, useNavigate } from "react-router-dom";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faRightToBracket } from "@fortawesome/free-solid-svg-icons";
import rigthImg from "../img/Right.jpg";
import axios from "axios";

const Ariza = () => {
  const[name, setName] = useState("");
  const[number, setNumber] = useState();
  const[summa, setSumma] = useState();
  const navigate = useNavigate();
  const sendData = () => {
    console.log(name, number, summa);
    axios .post("https://localhost:7200/ariza", {
      name : name,
      number : number,
      summa: summa
    })
    .then ((res) => {
      localStorage.setItem("tocen", res.data.token);
      navigate("/dashboard");
    })
    .catch((err) => {
      console.log(err);
    })
  }
  return (
    <ArizaWrapper>
      <header>
        <div className="head d-flex justify-content-between align-items-center">
          <div className="imgMetsenat">
            <img src={logo} alt="metsenat club" className="w-100 p-4" />
          </div>
          <div className="menuMetsenat d-flex align-items-center">
            <Link to={"/"} className="headLink">
              <p>Asosiy</p>
            </Link>
            <Link to={"/"} className="headLink">
              <p>Grantlar</p>
            </Link>
            <Link to={"/"} className="headLink">
              <p>Soliq imtiyozlari</p>
            </Link>
            <Link to={"/dashboard"} className="d-flex headLink ">
              <FontAwesomeIcon icon={faRightToBracket} className="mt-1" />
              <p className="ms-2">Kirish</p>
            </Link>
            <Link to={"/login"} className="headLink">
              <button className="btn headBut">Ro‘yxatdan o’tish</button>
            </Link>
          </div>
        </div>
      </header>
      <div className="ariza d-flex">
        <div className="w-50 left">
          <p className="title">Homiy sifatida ariza topshirish</p>
          <div className="d-flex userTah mt-2">
            <button className="btn jshah border-end-0">Jismoniy shaxs</button>
            <button className="btn yuridik border-start-0">
              Yuridik shaxs
            </button>
          </div>
          <div>
              <p className="mb-2 modTitle">F.I.Sh. (Familiya Ism Sharifingiz)</p>
              <input
                type="text"
                placeholder="Abdullayev Abdulla Abdulla o’g’li"
                className="form-control inputPlus"
                value={name} onChange={(e) => {setName(e.target.value)}}
              />
            </div>
            <div>
              <p className="mb-2 modTitle">Telefon raqamingiz</p>
              <input
                type="number"
                placeholder="+998 00 000-00-00"
                className="form-control inputPlus"
                value={number} onChange={(e) => {setNumber(e.target.value)}}
              />
            </div>
            <div>
              <p className="mb-2 modTitle">To‘lov summasi</p>
              <input
                type="number"
                placeholder="Summani kiriting"
                className="form-control inputPlus"
                value={summa} onChange={(e) => {setSumma(e.target.value)}}
              />
            </div>
            <button className="btn w-100 btn-primary mt-3" onClick={sendData}>Yuborish</button>
        </div>
        <div className="w-50 right">
          <img src={rigthImg} alt="" />
        </div>
      </div>
    </ArizaWrapper>
  );
};

export default Ariza;
