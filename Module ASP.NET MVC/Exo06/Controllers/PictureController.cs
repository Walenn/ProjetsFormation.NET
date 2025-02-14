﻿using Exo06.Data;
using Exo06.Entities;
using Exo06.Models;
using Exo06.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exo06.Controllers;

public class PictureController : Controller
{
    private readonly IPictureService _pictureService;

    public PictureController(IPictureService pictureService)
    {
        _pictureService = pictureService;
    }

    // GET : /Picture => Sert pour visualiser les images
    public IActionResult Index()
    {
        var pictures = _pictureService.GetAll();
        return View(pictures);
    }

    // GET : /Picture/Create => Sert à retourner le formulaire de création d'une image
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    // POST : /Picture/Create => Permet de réceptionner les informations d'image et de les traiter avant le retour à la page de listing
    public IActionResult Create(PictureCreateViewModel pictureVM)
    {
        if (_pictureService.Create(pictureVM) != null) return RedirectToAction(nameof(Index));
        return View(pictureVM);
    }
}