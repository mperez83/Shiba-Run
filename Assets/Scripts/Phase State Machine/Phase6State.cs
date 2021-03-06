﻿using UnityEngine;
using Prime31.StateKit;

public class Phase6State : SKState<PhaseHandler>
{
    BirdSpawner birdSpawner;

    public override void begin()
    {
        if (_context.currentlyResetting)
        {
            _context.currentlyResetting = false;
            _context.ResetGround();
            _context.groundPlayer = Object.Instantiate(_context.groundPlayerPrefab, new Vector2(-3.5f, 0f), Quaternion.identity);
            _context.groundPlayer.SetTargetPosOriginitionX(-3.5f);
            _context.groundScenery.active = true;
        }

        _context.music.time = GameMaster.instance.phase6Start;
        birdSpawner = Object.Instantiate(_context.birdSpawnerPrefab);
    }

    public override void update(float deltaTime)
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            _context.currentlyResetting = true;
            begin();
        }

        if (_context.music.time >= GameMaster.instance.phase7Start)
        {
            _machine.changeState<Phase7State>();
        }
    }

    public override void end()
    {
        Object.Destroy(birdSpawner);
    }
}