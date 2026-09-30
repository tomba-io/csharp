# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/)

### v1.1.1

- Fix: Bulk `LaunchAsync` now uses correct path (`/bulk/{type}/{id}`) and HTTP method (`PUT`)
- Fix: Bulk `DeleteAsync` now uses correct path (`/bulk/{type}/{id}/delete`)
- Fix: Bulk `ArchiveAsync` now uses correct HTTP method (`DELETE`)
- Fix: Correct API endpoint paths for email-verifier, email-sources, phone-finder, phone-validator, domain-suggestions, and email-format
- Fix: Correct parameter handling for domain-search and email-finder (query params instead of path params)
- Fix: Correct base paths for Keys, LeadsList, and LeadsAttributes services
- Feat: Add bulk type validation
- Feat: Add Leads, Location, Phone, Reveal, and Technology services

### v1.0.0

Initial commit
