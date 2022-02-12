{ pkgs ? import <nixpkgs> {} }:

pkgs.mkShell {
  buildInputs = [
    pkgs.hello
    pkgs.dotnet-sdk
    pkgs.dotnet-aspnetcore
    # keep this line if you use bash
    pkgs.bashInteractive
    pkgs.nodejs-17_x
    pkgs.nodePackages.pnpm
  ];
}
