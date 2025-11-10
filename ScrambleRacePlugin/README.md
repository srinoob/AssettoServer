# ScrambleRacePlugin
## Features
* `/scramble` command begins a 5 second countdown before announcing a race destination picked at random from a list
* Race destination list is configurable in the `extra_cfg.yml`
* Basic safety mechanism to prevent overlapping countdowns
## Configuration
Enable the plugin in `extra_cfg.yml`
```yaml
EnablePlugins:
- ScrambleRacePlugin
```
Example configuration (add to bottom of `extra_cfg.yml`)  
```yaml
---
!ScrambleRaceConfiguration
Destinations:
  - "Tatsumi PA"
  - "Shibaura PA"
  - "Yoyogi PA"
  - "Oi PA"
  - "Hewajima PA"
  - "Daishi PA"
  - "Shibuya Scramble Crossing"
  - "Shinjuku Station"
```
